using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IModulePageRepository : IRepositoryBase<ModulePage>
    {
        Task<ModulePage> GetModulePageByCodesAsync(string moduleCode, string pageCode);
    }
}
