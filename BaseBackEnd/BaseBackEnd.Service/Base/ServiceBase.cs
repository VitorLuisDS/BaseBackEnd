namespace BaseBackEnd.Service.Base
{
    //public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    //{
    //    private readonly IRepositoryBase<TEntity> _repositoryBase;

    //    public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
    //    {
    //        _repositoryBase = repositoryBase;
    //    }

    //    public async Task AddAsync(TEntity entity)
    //    {
    //        await _repositoryBase.AddAsync(entity);
    //    }

    //    public IQueryable<TEntity> Get(
    //        Expression<Func<TEntity, bool>> filter = default,
    //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
    //        bool asNoTracking = true,
    //        params Expression<Func<TEntity, object>>[] includes)
    //    {
    //        return _repositoryBase.Get(filter, orderBy, asNoTracking, includes);
    //    }

    //    public async Task<TEntity> GetByIdAsync(object id)
    //    {
    //        return await _repositoryBase.GetByIdAsync(id);
    //    }

    //    public async Task<DateTime> GetDatabaseDateTimeAsync()
    //    {
    //        return await _repositoryBase.GetDatabaseDateTimeAsync();
    //    }

    //    public void GetException(Exception ex)
    //    {
    //        _repositoryBase.GetException(ex);
    //    }

    //    public async Task<Guid> NewGuidDatabaseAsync()
    //    {
    //        return await _repositoryBase.NewGuidDatabaseAsync();
    //    }

    //    public void Remove(TEntity entity)
    //    {
    //        _repositoryBase.Remove(entity);
    //    }

    //    public void Update(TEntity entity)
    //    {
    //        _repositoryBase.Update(entity);
    //    }
    //}
}
