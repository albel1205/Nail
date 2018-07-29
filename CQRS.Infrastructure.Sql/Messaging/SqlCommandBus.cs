namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Messaging;

    public class SqlCommandBus : ICommandBus
    {
        private IMessageSender messageSender;



        public void Send(Envelope<ICommand> command)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<Envelope<ICommand>> commands)
        {
            throw new NotImplementedException();
        }
    }
}
