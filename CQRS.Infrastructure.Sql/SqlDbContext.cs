namespace Infrastructure.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public abstract class SqlDbContext : DbContext
    {
        public SqlDbContext(string connectionString)
            : base()
        {
            this.ConnectionString = connectionString;
        }

        protected string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.ConfigureModelCreating(modelBuilder);
        }

        protected abstract void ConfigureModelCreating(ModelBuilder modelBuilder);
    }
}
