using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MilesL.BotherMeNot.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MilesL.BotherMeNot.Api.Repositories
{
    public abstract class Repository<T, I> : IRepository<T, I> where T : class
    {
        protected readonly BotherMeNotDbContext dbContext;

        public Repository(BotherMeNotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<I>> Get(Expression<Func<T, bool>> query)
        {
            return await this.dbContext.Set<T>().AsNoTracking().Where(query).ToListAsync() as IEnumerable<I>;
        }

        public async Task<IEnumerable<I>> GetAll()
        {
            return await this.dbContext.Set<T>().AsNoTracking().ToListAsync() as IEnumerable<I>;
        }

        public async Task Create(I entity)
        {
            await this.dbContext.Set<T>().AddAsync(entity as T);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Update(I entity)
        {
            this.dbContext.Set<T>().Update(entity as T);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(I entity)
        {
            this.dbContext.Set<T>().Remove(entity as T);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
