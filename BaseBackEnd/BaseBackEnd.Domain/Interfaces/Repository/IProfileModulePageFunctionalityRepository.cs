using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IProfileModulePageFunctionalityRepository : IRepositoryBase<ProfileModulePageFunctionality>
    {
        Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsUserProfilesAsync(int moduleId, int pageId, int userId);
    }
}
