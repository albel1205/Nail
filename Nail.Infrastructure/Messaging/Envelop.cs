using System;
using System.Collections.Generic;
using System.Text;

namespace Nail.Infrastructure.Messaging
{
    public abstract class Envelop
    {
        public static Envelop<T> Create<T>(T body)
        {
            return new Envelop<T>(body);
        }
    }

    public class Envelop<T> : Envelop
    {
        public T Body { get; private set; }

        public Envelop(T body)
        {
            this.Body = body;
        }
    }
}
