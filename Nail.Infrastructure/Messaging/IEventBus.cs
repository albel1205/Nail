using System;
using System.Collections.Generic;
using System.Text;

namespace Nail.Infrastructure.Messaging
{
    public interface IEventBus
    {
        void Publish(Envelop<IEvent> @event);

        void Publish(IEnumerable<Envelop<IEvent>> events);
    }
}
