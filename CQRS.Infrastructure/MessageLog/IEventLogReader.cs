namespace CQRS.Infrastructure.MessageLog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging;

    public interface IEventLogReader
    {
        IEnumerable<IEvent> Query(QueryCriteria criteria);
    }
}
