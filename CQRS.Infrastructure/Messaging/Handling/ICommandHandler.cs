namespace Infrastructure.Messaging.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<T> : ICommandHandler
        where T : ICommand
    {
        void Handle(T command);
    }
}
