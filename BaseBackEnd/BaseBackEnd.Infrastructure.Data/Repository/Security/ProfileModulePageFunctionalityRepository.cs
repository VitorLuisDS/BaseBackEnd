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

        public async Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsUserProfilesAsync(int moduleId, int pageId, int userId)
        {
            var userProfilesIds = await _dbContext
                .UserProfile
                .Include(u => u.Profile)
                .Where(u => u.IdUser == userId &&
                            u.Status == Domain.Enums.StatusBase.Active &&
                            u.Profile.Status == Domain.Enums.StatusBase.Active)
                .Select(u => u.IdProfile)
                .ToArrayAsync();

            var functionalitiesCodes = await _dbSet
                .Include(p => p.ModulePageFunctionality.Functionality)
                .Include(p => p.ModulePageFunctionality.ModulePage.Page)
                .Include(p => p.Profile.UserProfiles)
                .Where(p => userProfilesIds.Contains(p.IdProfile) &&
                            p.IdModule == moduleId &&
                            p.IdPage == pageId &&
                            p.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.Functionality.Status == Domain.Enums.StatusBase.Active &&
                            p.ModulePageFunctionality.ModulePage.Page.Status == Domain.Enums.StatusBase.Active)
                .Select(p => p.ModulePageFunctionality.Functionality.Code)
                .Distinct()
                .ToArrayAsync();

            return functionalitiesCodes;
        }
    }
}
