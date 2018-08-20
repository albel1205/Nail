namespace Infrastructure.Sql.Messaging.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class MessageProcessor : IProcessor
    {
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        protected abstract void ProcessMessage(string payload);
    }
}
