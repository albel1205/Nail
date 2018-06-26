namespace Infrastructure.MessageLog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Messaging;

    public interface IEventLogReader
    {
        IEnumerable<IEvent> Query(QueryCriteria criteria);
    }
}
