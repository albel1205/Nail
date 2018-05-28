using CQRS.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.EventSourcing
{
    public interface IVersionedEvent : IEvent
    {
        int Version { get; }
    }
}
