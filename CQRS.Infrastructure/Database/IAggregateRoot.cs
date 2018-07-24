namespace Infrastructure.Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
