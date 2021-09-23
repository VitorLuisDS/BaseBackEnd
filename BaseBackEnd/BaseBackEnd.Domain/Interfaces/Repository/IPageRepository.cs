using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
        Task<Page> GetPageByCodeAsync(string code);
    }
}
