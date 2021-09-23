using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class ProfileModulePageFunctionalityRepository : RepositoryBase<ProfileModulePageFunctionality>, IProfileModulePageFunctionalityRepository
    {
        public ProfileModulePageFunctionalityRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<ProfileModulePageFunctionality> QueryBase()
        {
            return Get(
                filter: pmpf => pmpf.Status == StatusBase.Active &&
                                pmpf.ModulePageFunctionality.Status == StatusBase.Active &&
                                pmpf.ModulePageFunctionality.Functionality.Status == StatusBase.Active &&
                                pmpf.ModulePageFunctionality.ModulePage.Page.Status == StatusBase.Active,
                orderBy: null,
                asNoTracking: true,
                pmpf => pmpf.ModulePageFunctionality.Functionality,
                pmpf => pmpf.ModulePageFunctionality.ModulePage.Page,
                pmpf => pmpf.Profile.UserProfiles);
        }

        public async Task<IEnumerable<string>> GetFunctionalitiesCodesByIdsUserProfilesAsync(int moduleId, int pageId, int userId)
        {
            var userProfilesIds = await _dbContext
                .UserProfile
                .Include(up => up.Profile)
                .Where(up => up.IdUser == userId &&
                             up.Status == StatusBase.Active &&
                             up.Profile.Status == StatusBase.Active)
                .Select(up => up.IdProfile)
                .ToArrayAsync();

            if (userProfilesIds == default || !userProfilesIds.Any())
                return default;

            var functionalitiesCodes = await QueryBase()
                .Where(pmpf => userProfilesIds.Contains(pmpf.IdProfile) &&
                               pmpf.IdModule == moduleId &&
                               pmpf.IdPage == pageId)
                .Select(pmpf => pmpf.ModulePageFunctionality.Functionality.Code)
                .Distinct()
                .ToArrayAsync();

            return functionalitiesCodes;
        }
    }
}
