namespace Infrastructure.Sql.Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Database;
    using Infrastructure.Sql.Messaging;
    using Microsoft.EntityFrameworkCore;

    public class MessageUnitOfWork : IMessageUnitOfWork
    {
        private IAggregateRepository<Message> messageRepository;

        public IAggregateRepository<Message> MessageRepository
        {
            get
            {
                return this.messageRepository;
            }
        }

        public MessageUnitOfWork(DbContext dbContext, IAggregateRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
