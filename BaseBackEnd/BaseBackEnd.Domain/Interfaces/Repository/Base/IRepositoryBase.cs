using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(params object[] id);
        Task<DateTime> GetDatabaseDateTimeAsync();
        void GetException(Exception ex);
        Task<Guid> NewGuidDatabaseAsync();
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
