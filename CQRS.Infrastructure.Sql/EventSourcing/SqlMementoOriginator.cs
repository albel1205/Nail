using Infrastructure.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Sql.EventSourcing
{
    public class SqlMementoOriginator : IMementoOriginator
    {
        public IMemento SaveToMemento()
        {
            throw new NotImplementedException();
        }
    }
}
