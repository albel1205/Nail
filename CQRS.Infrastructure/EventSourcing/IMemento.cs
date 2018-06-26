using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EventSourcing
{
    public interface IMemento
    {
        int Version { get; }
    }
}
