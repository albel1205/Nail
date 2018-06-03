namespace CQRS.Infrastructure.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging;

    public interface IProcessManager
    {
        Guid Id { get; }

        bool IsCompleted { get; }

        IEnumerable<Envelope<ICommand>> Commands { get; }
    }
}
