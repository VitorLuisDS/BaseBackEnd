using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
        Task<Page> GetPageByCodeAsync(string code);
    }
}
