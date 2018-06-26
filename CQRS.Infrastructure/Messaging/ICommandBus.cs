namespace Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandBus
    {
        void Send(Envelope<ICommand> command);

        void Send(IEnumerable<Envelope<ICommand>> commands);
    }
}
