using System;
using System.Collections.Generic;
using System.Text;

namespace Nail.Infrastructure.Messaging
{
    public interface ICommandBus
    {
        void Send(Envelop<ICommand> command);

        void Send(IEnumerable<Envelop<ICommand>> commands);
    }
}
