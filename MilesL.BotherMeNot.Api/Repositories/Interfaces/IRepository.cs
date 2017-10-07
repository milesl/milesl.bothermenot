using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Repositories.Interfaces
{
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<I>> GetAll();

        Task<IEnumerable<I>> Get(Expression<Func<T, bool>> query);

        Task Create(I entity);

        Task Update(I entity);

        Task Delete(I entity);
    }
}
