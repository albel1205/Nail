using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Infrastructure.Messaging
{
    public static class EventBusExtensions
    {
        public static void Publish(this IEventBus eventBus, IEvent @event)
        {
            eventBus.Publish(new Envelop<IEvent>(@event));
        }

        public static void Publish(this IEventBus eventBus, IEnumerable<IEvent> events)
        {
            eventBus.Publish(events.Select(x => new Envelop<IEvent>(x)));
        }
    }
}
