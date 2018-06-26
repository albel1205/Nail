using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EventSourcing
{
    public abstract class EventSourced : IEventSourced
    {
        private readonly Dictionary<Type, Action<IVersionedEvent>> handlers = new Dictionary<Type, Action<IVersionedEvent>>();
        private readonly List<IVersionedEvent> pendingEvents = new List<IVersionedEvent>();

        private Guid id;
        private int version;

        public EventSourced(Guid id)
        {
            this.id = id;
        }

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public int Version
        {
            get
            {
                return this.version;
            }
        }

        public IEnumerable<IVersionedEvent> Events
        {
            get
            {
                return this.pendingEvents;
            }
        }

        protected void Handle<TEvent>(Action<TEvent> handler)
            where TEvent : IEvent
        {
            this.handlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
        }

        protected void LoadFrom(IEnumerable<IVersionedEvent> pastEvents)
        {
            foreach(var @event in pastEvents)
            {
                this.handlers[@event.GetType()].Invoke(@event);
                this.version = @event.Version;
            }
        }

        protected void Update(VersionedEvent e)
        {
            e.Version = this.Version + 1;
            e.SourceId = this.Id;

            this.handlers[e.GetType()].Invoke(e);
            this.version = e.Version;
            this.pendingEvents.Add(e);
        }
    }
}
