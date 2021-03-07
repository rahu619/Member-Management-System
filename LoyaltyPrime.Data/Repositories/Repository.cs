using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data.Repositories
{
    /// <summary>
    /// The base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves the entity by ID 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async ValueTask<TEntity> GetByIDAsync(int id)
        {
            return await this._dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await this._dbContext.Set<TEntity>().AddAsync(entity);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this._dbContext.Set<TEntity>().AddRangeAsync(entities);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }



    }
}
