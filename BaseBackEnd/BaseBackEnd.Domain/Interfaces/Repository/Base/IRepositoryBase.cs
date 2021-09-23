using System.Linq.Expressions;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = default,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = default,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(object id);
        Task<DateTime> GetDatabaseDateTimeAsync();
        void GetException(Exception ex);
        Task<Guid> NewGuidDatabaseAsync();
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
