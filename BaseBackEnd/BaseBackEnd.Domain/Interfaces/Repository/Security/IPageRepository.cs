using BaseBackEnd.Security.Domain.Entities.Security;
using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository.Security
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
        Task<Page> GetPageByCodeAsync(string code);
    }
}
