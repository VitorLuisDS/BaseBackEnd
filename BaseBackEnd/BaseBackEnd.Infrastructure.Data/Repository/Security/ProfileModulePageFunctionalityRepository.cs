using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class ProfileModulePageFunctionalityRepository : RepositoryBase<ProfileModulePageFunctionality>, IProfileModulePageFunctionalityRepository
    {
        public ProfileModulePageFunctionalityRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsAsync(int moduleId, int pageId, int profileId)
        {
            var functionalitiesCodes = await _dbSet
                .Include(p => p.ModulePageFunctionality.Functionality)
                .Include(p => p.ModulePageFunctionality.ModulePage.Page)
                .Where(p => p.IdProfile == profileId &&
                            p.IdModule == moduleId &&
                            p.IdPage == pageId &&
                            p.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.Functionality.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.ModulePage.Page.Status == Domain.Enums.StatusBase.Active)
                .Select(p => p.ModulePageFunctionality.Functionality.Code)
                .ToArrayAsync();

            return functionalitiesCodes;
        }
    }
}
