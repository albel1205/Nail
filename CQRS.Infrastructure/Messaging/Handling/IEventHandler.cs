﻿namespace CQRS.Infrastructure.Messaging.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventHandler
    {
    }

    public interface IEventHandler<T> : IEventHandler
        where T : IEvent
    {
        void Handle(T @event);
    }

    public interface IEnvelopedEventHandler<T> : IEventHandler
        where T : IEvent
    {
        void Handle(Envelope<T> envelop);
    }
}
