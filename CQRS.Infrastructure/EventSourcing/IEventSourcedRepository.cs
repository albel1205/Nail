namespace Infrastructure.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventSourcedRepository<TEventSourced>
        where TEventSourced : IEventSourced
    {
        /// <summary>
        /// Find TEventSourced entity
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <returns>return <see cref="TEventSourced"/> or null if the <see cref="TEventSourced"/> did not exist</returns>
        TEventSourced Find(Guid id);

        /// <summary>
        /// Get <see cref="TEventSourced"/> entity
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <returns>return <see cref="TEventSourced"/></returns>
        /// throw <exception cref="EntityNotFoundException"> if the entity is not found
        TEventSourced Get(Guid id);

        /// <summary>
        /// Saves the event sourced entity.
        /// </summary>
        /// <param name="eventSourced">The entity.</param>
        /// <param name="correlationId">A correlation id to use when publishing events.</param>
        void Save(TEventSourced eventSourced, string correlationId);
    }
}
