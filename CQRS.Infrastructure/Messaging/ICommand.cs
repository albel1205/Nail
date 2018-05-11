namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommand
    {
        Guid Id { get; }
    }
}
