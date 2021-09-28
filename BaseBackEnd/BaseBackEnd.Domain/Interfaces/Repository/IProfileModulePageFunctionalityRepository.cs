using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IProfileModulePageFunctionalityRepository : IRepositoryBase<ProfileModulePageFunctionality>
    {
        Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsUserProfilesAsync(int moduleId, int pageId, int userId);
    }
}
