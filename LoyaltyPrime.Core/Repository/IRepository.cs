using LoyaltyPrime.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        ValueTask<TEntity> GetByIDAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);

    }
}
