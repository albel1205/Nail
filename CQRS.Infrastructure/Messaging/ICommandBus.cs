namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandBus
    {
        void Send(Envelop<ICommand> command);

        void Send(IEnumerable<Envelop<ICommand>> commands);
    }
}
