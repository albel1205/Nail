namespace Infrastructure.Messaging.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandHandlerRegistry
    {
        void Register(ICommandHandler commandHandler);
    }
}
