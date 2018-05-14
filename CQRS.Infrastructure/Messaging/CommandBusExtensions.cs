namespace CQRS.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class CommandBusExtensions
    {
        public static void Send(this ICommandBus commandBus, ICommand command)
        {
            commandBus.Send(new Envelop<ICommand>(command));
        }

        public static void Send(this ICommandBus commandBus, IEnumerable<ICommand> commands)
        {
            commandBus.Send(commands.Select(x => new Envelop<ICommand>(x)));
        }
    }
}
