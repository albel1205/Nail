namespace CQRS.Infrastructure.MessageLog
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging;

    public interface IEventQuery : IEnumerable<IEvent>
    {
        IEnumerable<IEvent> Execute();

        IEventQuery FromSourceType(string sourceType);

        IEventQuery FromSourceId(string sourceId);

        IEventQuery FromAssemblyName(string assemblyName);

        IEventQuery FromNamespace(string @namespace);

        IEventQuery WithFullName(string fullname);

        IEventQuery WithTypeName(string typeName);

        IEventQuery Until(DateTime date);
    }
}
