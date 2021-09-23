using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IModulePageRepository : IRepositoryBase<ModulePage>
    {
        Task<ModulePage> GetModulePageByCodesAsync(string moduleCode, string pageCode);
    }
}
