using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interface representing a repository
    /// </summary>
    /// <typeparam name="T">Domain model concrete type</typeparam>
    /// <typeparam name="I">Interface representing the domain model</typeparam>
    public interface IRepository<T, I>
        where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>A collection of type I</returns>
        Task<IEnumerable<I>> GetAll();

        /// <summary>
        /// Gets the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A collection of type I</returns>
        Task<IEnumerable<I>> Get(Expression<Func<T, bool>> query);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Nothing</returns>
        Task Create(I entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Nothing</returns>
        Task Update(I entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Nothing</returns>
        Task Delete(I entity);
    }
}
