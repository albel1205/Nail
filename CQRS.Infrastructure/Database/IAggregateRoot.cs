using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
