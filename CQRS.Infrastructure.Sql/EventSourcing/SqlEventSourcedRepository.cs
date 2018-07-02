using Infrastructure.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Sql.EventSourcing
{
    public class SqlEventSourcedRepository<T> : IEventSourcedRepository<T>
        where T : IEventSourced
    {
        public T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(T eventSourced, string correlationId)
        {
            throw new NotImplementedException();
        }
    }
}
