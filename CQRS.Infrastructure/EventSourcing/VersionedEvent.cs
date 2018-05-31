using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.EventSourcing
{
    public abstract class VersionedEvent : IVersionedEvent
    {
        public int Version { get; set; }

        public Guid SourceId { get; set; }
    }
}
