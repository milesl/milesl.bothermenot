using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;

namespace MilesL.BotherMeNot.Api.Repositories
{
    /// <summary>
    /// Abstract repository implementation
    /// </summary>
    /// <typeparam name="T">Domain model concrete type</typeparam>
    /// <typeparam name="I">Interface representing the domain model</typeparam>
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Interfaces.IRepository{T, I}" />
    public abstract class Repository<T, I> : IRepository<T, I>
        where T : class
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly BotherMeNotDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T, I}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(BotherMeNotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// A collection of type I
        /// </returns>
        public async Task<IEnumerable<I>> Get(Expression<Func<T, bool>> query)
        {
            return await this.dbContext.Set<T>().AsNoTracking().Where(query).ToListAsync() as IEnumerable<I>;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// A collection of type I
        /// </returns>
        public async Task<IEnumerable<I>> GetAll()
        {
            return await this.dbContext.Set<T>().AsNoTracking().ToListAsync() as IEnumerable<I>;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Nothing
        /// </returns>
        public async Task Create(I entity)
        {
            await this.dbContext.Set<T>().AddAsync(entity as T);
            await this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Nothing
        /// </returns>
        public async Task Update(I entity)
        {
            this.dbContext.Set<T>().Update(entity as T);
            await this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Nothing
        /// </returns>
        public async Task Delete(I entity)
        {
            this.dbContext.Set<T>().Remove(entity as T);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
