namespace Infrastructure.Database
{
    using System;

    public interface IAggregateRepository<T> : IDisposable
        where T : IAggregateRoot
    {
        T Find(Guid Id);

        void Save(T aggregate);
    }
}
