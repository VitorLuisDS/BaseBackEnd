using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Service.Services.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms.PageVms;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Service.Services.Security
{
    public class AuthorizationService : ServiceBase<ProfileModulePageFunctionality>, IAuthorizationService
    {
        private readonly IProfileModulePageFunctionalityRepository _profileModulePageFunctionalityRepository;
        private readonly IModulePageRepository _modulePageRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ITokenService _tokenService;

        public AuthorizationService(
            IProfileModulePageFunctionalityRepository profileModulePageFunctionalityRepository,
            IModulePageRepository modulePageRepository,
            ISessionRepository sessionRepository,
            ITokenService tokenService
            ) : base(profileModulePageFunctionalityRepository)
        {
            _profileModulePageFunctionalityRepository = profileModulePageFunctionalityRepository;
            _modulePageRepository = modulePageRepository;
            _sessionRepository = sessionRepository;
            _tokenService = tokenService;
        }

        public async Task<PageAuthorizationOutputVm> AuthorizeUserAsync(string accessToken, PageAuthorizationInputVm pageAuthorizationInputVm)
        {
            var outputVm = new PageAuthorizationOutputVm();

            var user = await GetUserFromTokenAsync(accessToken);
            if (user is null)
                return default;

            var modulePage = await _modulePageRepository.GetModulePageByCodesAsync(pageAuthorizationInputVm.ModuleCode, pageAuthorizationInputVm.PageCode);
            if (modulePage is null)
                return default;

            var profileModulePageFunctionalities = await _profileModulePageFunctionalityRepository.GetFunctionalitiesCodesByIdsUserProfilesAsync(modulePage.Module.Id, modulePage.Page.Id, user.Id);
            if (profileModulePageFunctionalities is null)
                return default;

            outputVm.ModuleCode = modulePage.Module.Code;
            outputVm.PageCode = modulePage.Page.Code;
            outputVm.AllowedFunctionalities = profileModulePageFunctionalities.ToArray();

            return outputVm;
        }

        private async Task<User> GetUserFromTokenAsync(string accessToken)
        {
            var sid = _tokenService.GetSidFromToken(accessToken);
            if (sid == default)
                return default;

            var user = await _sessionRepository.GetUserFromSessionIdAsync(sid);
            if (user is null)
                return default;

            return user;
        }
    }
}
