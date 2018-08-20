namespace Infrastructure.Sql.Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Database;
    using Infrastructure.Sql.Messaging;

    public interface IMessageUnitOfWork : IUnitOfWork
    {
        IAggregateRepository<Message> MessageRepository { get; }
    }
}
