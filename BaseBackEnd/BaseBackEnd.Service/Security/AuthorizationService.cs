﻿using BaseBackEnd.Service.Base;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Service.Security
{
    public class AuthorizationService : ServiceBase<ProfileModulePageFunctionality>, IAuthorizationService
    {
        private readonly IProfileModulePageFunctionalityRepository _profileModulePageFunctionalityRepository;
        private readonly IModulePageRepository _modulePageRepository;

        public AuthorizationService(
            IProfileModulePageFunctionalityRepository profileModulePageFunctionalityRepository,
            IModulePageRepository modulePageRepository
            ) : base(profileModulePageFunctionalityRepository)
        {
            _profileModulePageFunctionalityRepository = profileModulePageFunctionalityRepository;
            _modulePageRepository = modulePageRepository;
        }

        public async Task<PageAuthorizationOutputVm> GetPageAuthorizationByUserAsync(int userId, PageAuthorizationInputVm pageAuthorizationInputVm)
        {
            if (userId == default)
                return default;

            var modulePage = await _modulePageRepository.GetModulePageByCodesAsync(pageAuthorizationInputVm.ModuleCode, pageAuthorizationInputVm.PageCode);
            if (modulePage == default)
                return default;

            var profileModulePageFunctionalities = await _profileModulePageFunctionalityRepository.GetFunctionalitiesCodesByIdsUserProfilesAsync(modulePage.Module.Id, modulePage.Page.Id, userId);

            var outputVm = new PageAuthorizationOutputVm
            {
                ModuleCode = modulePage.Module.Code,
                PageCode = modulePage.Page.Code,
                AllowedFunctionalities = profileModulePageFunctionalities?.ToArray()
            };

            return outputVm;
        }
    }
}
