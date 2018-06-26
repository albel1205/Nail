﻿namespace Infrastructure.Messaging.Handling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventHandlerRegistry
    {
        void Register(IEventHandler eventHandler);
    }
}
