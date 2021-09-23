using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        Task<Module> GetModuleByCodeAsync(string code);
    }
}
