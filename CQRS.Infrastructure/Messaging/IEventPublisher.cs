namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Define an object which exposes events
    /// </summary>
    public interface IEventPublisher
    {
        IEnumerable<IEvent> Events { get; }
    }
}
