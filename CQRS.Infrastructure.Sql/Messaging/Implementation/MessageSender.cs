namespace Infrastructure.Sql.Messaging.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Database;

    public class MessageSender : IMessageSender
    {
        private IAggregateRepository<Message> messageRepository;

        public MessageSender(IAggregateRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public void Send(Message message)
        {
            this.messageRepository.Save(message);
        }

        /// <summary>
        /// Send multiple messages at once
        /// </summary>
        /// <param name="messages">List of <see cref="Message"/></param>
        /// <remarks>TODO: Do rollback all messages on failure</remarks>
        public void Send(IEnumerable<Message> messages)
        {
            foreach (var message in messages)
            {
                this.messageRepository.Save(message);
            }
        }
    }
}
