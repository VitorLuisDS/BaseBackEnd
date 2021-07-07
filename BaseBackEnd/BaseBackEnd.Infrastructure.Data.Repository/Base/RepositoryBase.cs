using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.CrossCutting.Exceptions;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context.DatabaseFunctions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ProjectBaseContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ProjectBaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> QueryBase() => Get();

        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != default)
            {
                query = query
                    .Where(filter);
            }

            if (includes != default)
            {
                query = query
                    .IncludeMultiple(includes);
            }

            if (orderBy != default)
            {
                query = orderBy(query)
                    .AsQueryable();
            }

            if (asNoTracking)
            {
                return query
                    .AsNoTracking();
            }
            else
            {
                return query;
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

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
            if (ex.Message.Contains("FK_") || (ex.InnerException != default && ex.InnerException.Message.Contains("FK_")))
            {
                throw new RequestErrorException("Item(s) not found for registration.");
            }
            if (ex.Message.Contains("PK_") || (ex.InnerException != default && ex.InnerException.Message.Contains("PK_")))
            {
                throw new ConstraintViolationException("Item already exists.");
            }
            else
            {
                throw ex;
            }
        }
    }

    internal static class QueryExtension
    {
        internal static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != default)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
