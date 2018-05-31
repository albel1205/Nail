using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.EventSourcing
{
    public interface IMemento
    {
        int Version { get; }
    }
}
