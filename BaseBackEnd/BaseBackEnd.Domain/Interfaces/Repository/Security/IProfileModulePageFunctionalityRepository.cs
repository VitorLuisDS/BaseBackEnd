using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface IProfileModulePageFunctionalityRepository : IRepositoryBase<ProfileModulePageFunctionality>
    {
        Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsAsync(int moduleId, int pageId, int profileId);
    }
}
