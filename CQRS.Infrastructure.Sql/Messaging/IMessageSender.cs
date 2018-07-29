namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessageSender
    {
        void Send(Message message);

        void Send(IEnumerable<Message> messages);
    }
}
