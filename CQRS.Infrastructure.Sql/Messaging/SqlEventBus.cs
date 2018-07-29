namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Messaging;

    public class SqlEventBus : IEventBus
    {
        private IMessageSender messageSender;

        public void Publish(Envelope<IEvent> @event)
        {
            throw new NotImplementedException();
        }

        public void Publish(IEnumerable<Envelope<IEvent>> events)
        {
            throw new NotImplementedException();
        }
    }
}
