using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms.PageVms;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthorizationService : IServiceBase<ProfileModulePageFunctionality>
    {
        Task<PageAuthorizationOutputVm> AuthorizeUserAsync(string accessToken, PageAuthorizationInputVm pageAuthorizationInputVm);
    }
}
