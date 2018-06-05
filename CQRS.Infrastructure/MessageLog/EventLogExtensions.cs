namespace CQRS.Infrastructure.MessageLog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging;

    public static class EventLogExtensions
    {
        public static IEnumerable<IEvent> ReadAll(this IEventLogReader log)
        {
            return log.Query(new QueryCriteria());
        }

        public static IEventQuery Query(this IEventLogReader reader)
        {
            return new EventQuery(reader);
        }
    }
}
