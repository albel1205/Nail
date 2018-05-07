namespace Nail.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Envelop
    {
        public static Envelop<T> Create<T>(T body)
        {
            return new Envelop<T>(body);
        }
    }

    public class Envelop<T> : Envelop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelop{T}"/> class.
        /// </summary>
        /// <param name="body">body of the Envelop</param>
        public Envelop(T body)
        {
            this.Body = body;
        }

        public T Body { get; private set; }
    }
}
