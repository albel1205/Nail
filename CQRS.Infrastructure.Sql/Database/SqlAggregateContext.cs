namespace CQRS.Infrastructure.Sql.Database
{
    using System;
    using global::Infrastructure.Database;
    using global::Infrastructure.Messaging;
    using Microsoft.EntityFrameworkCore;

    public class SqlAggregateContext<T> : IDataContext<T>
        where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;
        private readonly IEventBus eventBus;

        public SqlAggregateContext(DbContext dbContext, IEventBus eventBus)
        {
            this.dbContext = dbContext;
            this.eventBus = eventBus;
        }

        ~SqlAggregateContext()
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

        public void Save(T aggregate)
        {
            var entity = this.dbContext.Entry<T>(aggregate);

            if (entity.State == EntityState.Detached)
            {
                this.dbContext.Set<T>().Add(aggregate);
            }

            this.dbContext.SaveChanges();

            if (aggregate is IEventPublisher publisher)
            {
                this.eventBus.Publish(publisher.Events);
            }
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
