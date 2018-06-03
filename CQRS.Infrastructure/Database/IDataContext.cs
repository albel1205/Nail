namespace CQRS.Infrastructure.Database
{
    using System;

    public interface IDataContext<T> :  IDisposable
        where T : IAggregateRoot
    {
        T Find(Guid Id);

        void Save(T aggregate);
    }
}
