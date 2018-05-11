namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventBus
    {
        void Publish(Envelop<IEvent> @event);

        void Publish(IEnumerable<Envelop<IEvent>> events);
    }
}
