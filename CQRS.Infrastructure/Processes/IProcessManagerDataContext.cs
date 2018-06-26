namespace Infrastructure.Processes
{
    using System;
    using System.Linq.Expressions;

    public interface IProcessManagerDataContext<T> : IDisposable
        where T : IProcessManager
    {
        T Find(T processManager);

        void Save(T processManager);

        T Find(Expression<Func<T, bool>> predicate, bool includeComplete = false);
    }
}
