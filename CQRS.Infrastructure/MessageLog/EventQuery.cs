namespace CQRS.Infrastructure.MessageLog
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using CQRS.Infrastructure.Messaging;

    public class EventQuery : IEventQuery, IEnumerable<IEvent>
    {
        private IEventLogReader logReader;
        private QueryCriteria queryCriteria = new QueryCriteria();

        public EventQuery(IEventLogReader logReader)
        {
            this.logReader = logReader;
        }

        public IEnumerable<IEvent> Execute()
        {
            return this.logReader.Query(this.queryCriteria);
        }

        public IEventQuery FromAssemblyName(string assemblyName)
        {
            this.queryCriteria.AssemblyNames.Add(assemblyName);
            return this;
        }

        public IEventQuery FromNamespace(string @namespace)
        {
            this.queryCriteria.Namespaces.Add(@namespace);
            return this;
        }

        public IEventQuery FromSourceId(string sourceId)
        {
            this.queryCriteria.SourceIds.Add(sourceId);
            return this;
        }

        public IEventQuery FromSourceType(string sourceType)
        {
            this.queryCriteria.SourceTypes.Add(sourceType);
            return this;
        }

        public IEnumerator<IEvent> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEventQuery Until(DateTime date)
        {
            this.queryCriteria.EndDate = date;
            return this;
        }

        public IEventQuery WithFullName(string fullname)
        {
            this.queryCriteria.FullNames.Add(fullname);
            return this;
        }

        public IEventQuery WithTypeName(string typeName)
        {
            this.queryCriteria.TypeNames.Add(typeName);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
