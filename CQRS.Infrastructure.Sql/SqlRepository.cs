namespace Infrastructure.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Database;
    using Infrastructure.Messaging;
    using Microsoft.EntityFrameworkCore;

    public class SqlRepository<T> : IAggregateRepository<T>
        where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;

        public SqlRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        ~SqlRepository()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Find(Guid Id)
        {
            return this.dbContext.Set<T>().Find(Id);
        }

        public virtual void Save(T aggregate)
        {
            var entity = this.dbContext.Entry<T>(aggregate);

            if (entity.State == EntityState.Detached)
            {
                this.dbContext.Set<T>().Add(aggregate);
            }

            this.dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
