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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        protected readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<TEntity> GetByIDAsync(int id)
        {
            return await this._dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._dbContext.Set<TEntity>().ToListAsync();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this._dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Remove(entity);
        }



    }
}
