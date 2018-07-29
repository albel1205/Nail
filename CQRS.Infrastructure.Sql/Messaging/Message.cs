namespace Infrastructure.Sql.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infrastructure.Database;

    public class Message : IAggregateRoot
    {
        public Message(string body, string correlationId = null, DateTime? deliveryDate = null)
        {
            this.Id = Guid.NewGuid();
            this.Body = body;
            this.CorrelationId = correlationId;
            this.DeliveryDate = deliveryDate;
        }

        public string Body { get; private set; }

        public string CorrelationId { get; private set; }

        public DateTime? DeliveryDate { get; private set; }

        public Guid Id { get; set; }
    }
}
