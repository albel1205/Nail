namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMemento
    {
        int Version { get; }
    }
}
