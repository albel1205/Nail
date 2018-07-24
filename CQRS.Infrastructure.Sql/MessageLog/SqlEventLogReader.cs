namespace Infrastructure.Sql.MessageLog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.MessageLog;
    using Infrastructure.Messaging;

    public class SqlEventLogReader : IEventLogReader
    {
        public IEnumerable<IEvent> Query(QueryCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
