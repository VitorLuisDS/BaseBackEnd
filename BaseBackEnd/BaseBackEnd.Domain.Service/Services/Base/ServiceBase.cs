using BaseBackEnd.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Service.Services.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repositoryBase.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = true,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return await _repositoryBase.GetAsync(filter, orderBy, asNoTracking, includes);
        }

        public async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }

        public async Task<DateTime> GetDatabaseDateTimeAsync()
        {
            return await _repositoryBase.GetDatabaseDateTimeAsync();
        }

        public void GetException(Exception ex)
        {
            _repositoryBase.GetException(ex);
        }

        public async Task<Guid> NewGuidDatabaseAsync()
        {
            return await _repositoryBase.NewGuidDatabaseAsync();
        }

        public void Remove(TEntity entity)
        {
            _repositoryBase.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repositoryBase.Update(entity);
        }
    }
}
