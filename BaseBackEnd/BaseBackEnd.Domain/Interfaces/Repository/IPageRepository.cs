using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
        Task<Page> GetPageByCodeAsync(string code);
    }
}
