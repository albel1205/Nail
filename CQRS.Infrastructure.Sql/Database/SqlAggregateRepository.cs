namespace CQRS.Infrastructure.Sql.Database
{
    using System;
    using global::Infrastructure.Database;
    using global::Infrastructure.Messaging;
    using global::Infrastructure.Sql;
    using Microsoft.EntityFrameworkCore;

    public class SqlAggregateRepository<T> : SqlRepository<T>
        where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;
        private readonly IEventBus eventBus;

        public SqlAggregateRepository(DbContext dbContext, IEventBus eventBus)
            : base(dbContext)
        {
            this.eventBus = eventBus;
        }

        public override void Save(T aggregate)
        {
            base.Save(aggregate);

            if (aggregate is IEventPublisher publisher)
            {
                this.eventBus.Publish(publisher.Events);
            }
        }
    }
}
