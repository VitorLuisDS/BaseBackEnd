using BaseBackEnd.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Context.DatabaseFunctions;
using BaseBackEnd.Infrastructure.Util.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        readonly ProjectBaseContext _dbContext;
        readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ProjectBaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query
                    .Where(filter);

            if (includes != null)
                query = query
                    .IncludeMultiple(includes);

            if (orderBy != null)
                query = orderBy(query)
                    .AsQueryable();

            if (asNoTracking)
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            else
                return await query
                    .ToListAsync();

        }

        protected async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async void AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        protected void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        protected void Remove(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbContext.Remove(entity);
        }

        public async Task<DateTime> GetDatabaseDateTimeAsync()
        {
            var db = await _dbContext.Set<DbFuncs>().FirstOrDefaultAsync();
            return db.DateTime;
        }

        public async Task<Guid> NewGuidDatabaseAsync()
        {
            var db = await _dbContext.Set<DbFuncs>().FirstOrDefaultAsync();
            return db.NewId;
        }

        public void GetException(Exception ex)
        {
            if (ex.Message.Contains("FK_") || (ex.InnerException != null && ex.InnerException.Message.Contains("FK_")))
            {
                throw new RequestErrorException("Item(s) not found for registration.");
            }
            if (ex.Message.Contains("PK_") || (ex.InnerException != null && ex.InnerException.Message.Contains("PK_")))
            {
                throw new ConstraintViolationException("Item already exists.");
            }
            else
            {
                throw ex;
            }
        }
    }

    static class QueryExtension
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
