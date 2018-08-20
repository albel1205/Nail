using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Sql.Database
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
