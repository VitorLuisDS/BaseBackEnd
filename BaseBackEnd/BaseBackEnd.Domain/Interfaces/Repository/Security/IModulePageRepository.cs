using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface IModulePageRepository : IRepositoryBase<ModulePage>
    {
        Task<ModulePage> GetModulePageByCodesAsync(string moduleCode, string pageCode);
    }
}
