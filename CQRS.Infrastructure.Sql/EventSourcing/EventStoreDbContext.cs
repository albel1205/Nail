namespace Infrastructure.Sql.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class EventStoreDbContext : SqlDbContext
    {
        public EventStoreDbContext(string connectionString)
            : base(connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbSet<Event> Events { get; set; }

        protected override void ConfigureModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .ToTable("Events")
                .HasKey(x => new { x.AggregateId, x.AggregateType, x.Version });
        }
    }
}
