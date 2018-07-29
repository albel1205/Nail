namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessageReceiver
    {
        void Start();

        void Stop();
    }
}
