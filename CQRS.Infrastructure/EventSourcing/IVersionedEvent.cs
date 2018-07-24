namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Messaging;

    public interface IVersionedEvent : IEvent
    {
        int Version { get; }
    }
}
