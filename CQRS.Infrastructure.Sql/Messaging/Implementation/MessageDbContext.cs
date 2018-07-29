namespace Infrastructure.Sql.Messaging.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class MessageDbContext : SqlDbContext
    {
        public MessageDbContext(string connectionString)
            : base(connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbSet<Message> Messages { get; set; }

        protected override void ConfigureModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .ToTable("Messages")
                .HasKey(x => new { x.Id });
        }
    }
}
