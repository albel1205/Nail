namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEvent
    {
        /// <summary>
        /// Gets the identifier of source where the event come from
        /// </summary>
        Guid SourceId { get; }
    }
}
