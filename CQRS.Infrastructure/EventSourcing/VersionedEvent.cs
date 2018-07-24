namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class VersionedEvent : IVersionedEvent
    {
        public int Version { get; set; }

        public Guid SourceId { get; set; }
    }
}
