using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.Database
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
