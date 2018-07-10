using Microsoft.EntityFrameworkCore;
using Infrastructure.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Infrastructure.Serialization;
using Infrastructure.Messaging;

namespace Infrastructure.Sql.EventSourcing
{
    public class SqlEventSourcedRepository<T> : IEventSourcedRepository<T>
        where T : class, IEventSourced
    {
        private string sourceType = typeof(T).Name;
        private ITextSerializer serializer;
        private EventStoreDbContext eventStoreDbContext;
        private Func<Guid, IEnumerable<IVersionedEvent>, T> entityFactory;
        private IEventBus eventBus;

        public SqlEventSourcedRepository(EventStoreDbContext dbContext, IEventBus eventBus)
        {
            this.eventStoreDbContext = dbContext;
            this.eventBus = eventBus;

            var constructor = typeof(T).GetConstructor(new[] { typeof(Guid), typeof(IEnumerable<IVersionedEvent>) });
            if (constructor == null)
            {
                throw new InvalidCastException("Type T must contain a constructor of (Guid, IEnumberable<IVersionedEvent>)");
            }

            this.entityFactory = (id, events) => (T)constructor.Invoke(new object[] { id, events });
        }

        public T Find(Guid id)
        {
            var events = this.eventStoreDbContext.Set<Event>()
                .Where(x => x.AggregateId == id && x.AggregateType == this.sourceType)
                .OrderBy(x => x.Version)
                .AsEnumerable()
                .Select(this.Deserialize);

            if (events.Any())
            {
                return this.entityFactory.Invoke(id, events);
            }

            return null;
        }

        public T Get(Guid id)
        {
            var @event = this.Find(id);
            if (@event == null)
            {
                throw new EntityNotFoundException(id, this.sourceType);
            }

            return @event;
        }

        public void Save(T eventSourced, string correlationId)
        {
            var events = eventSourced.Events.ToList();

            using (this.eventStoreDbContext as IDisposable)
            {
                var eventSet = this.eventStoreDbContext.Set<Event>();
                foreach (var @event in events)
                {
                    eventSet.Add(this.Serialize(@event, correlationId));
                }

                this.eventStoreDbContext.SaveChanges();
            }

            this.eventBus.Publish(events.Select(x => new Envelope<IEvent>(x) { CorrelationId = correlationId }));
        }

        private Event Serialize(IVersionedEvent e, string correlationId)
        {
            Event serialized;
            using (var writer = new StringWriter())
            {
                this.serializer.Serialize(writer, e);
                serialized = new Event
                {
                    AggregateId = e.SourceId,
                    AggregateType = this.sourceType,
                    Version = e.Version,
                    Payload = writer.ToString(),
                    CorrelationId = correlationId
                };
            }

            return serialized;
        }

        private IVersionedEvent Deserialize(Event @event)
        {
            using (var reader = new StringReader(@event.Payload))
            {
                return (IVersionedEvent)this.serializer.Deserialize(reader);
            }
        }
    }
}
