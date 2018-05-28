namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Envelope
    {
        public static Envelope<T> Create<T>(T body)
        {
            return new Envelope<T>(body);
        }
    }

    public class Envelope<T> : Envelope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{T}"/> class.
        /// </summary>
        /// <param name="body">body of the Envelop</param>
        public Envelope(T body)
        {
            this.Body = body;
        }

        public T Body { get; private set; }

        public TimeSpan Delay { get; set; }

        public TimeSpan TimeToLive { get; set; }

        public string CorrelationId { get; set; }

        public string MessageId { get; set; }

        public static implicit operator Envelope<T>(T body)
        {
            return Envelope.Create<T>(body);
        }
    }
}
