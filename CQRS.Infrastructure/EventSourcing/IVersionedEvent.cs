using Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EventSourcing
{
    public interface IVersionedEvent : IEvent
    {
        int Version { get; }
    }
}
