namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessageReceiver
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        void Start();

        void Stop();
    }
}
