namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventSourced
    {
        Guid Id { get; }

        int Version { get; }

        IEnumerable<IVersionedEvent> Events { get; }
    }
}
