namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging.Handling;

    public class EventDispatcher
    {
        private Dictionary<Type, List<Tuple<Type, Action<Envelop>>>> handlersByEventType;
        private Dictionary<Type, Action<IEvent, string, string, string>> dispatchersByEventType;

        public EventDispatcher()
        {
            this.handlersByEventType = new Dictionary<Type, List<Tuple<Type, Action<Envelop>>>>();
            this.dispatchersByEventType = new Dictionary<Type, Action<IEvent, string, string, string>>();
        }

        public EventDispatcher(IEnumerable<IEventHandler> handlers)
            : this()
        {
            this.Register(handlers);
        }

        public void Register(IEnumerable<IEventHandler> handlers)
        {

        }

        public void DispatchEvent(IEvent @event)
        {
            this.DispatchEvent(@event, null, null, string.Empty);
        }

        public void DispatchEvents(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                this.DispatchEvent(@event);
            }
        }

        public void DispatchEvent(IEvent @event, string messageId, string correlationId, string traceIdentifier)
        {
            Action<IEvent, string, string, string> dispatch = null;

            // invoke registered handler
            if (this.dispatchersByEventType.TryGetValue(@event.GetType(), out dispatch))
            {
                dispatch(@event, messageId, correlationId, traceIdentifier);
            }

            // invoke default handler
            if (this.dispatchersByEventType.TryGetValue(typeof(IEvent), out dispatch))
            {
                dispatch(@event, messageId, correlationId, traceIdentifier);
            }
        }
    }
}
