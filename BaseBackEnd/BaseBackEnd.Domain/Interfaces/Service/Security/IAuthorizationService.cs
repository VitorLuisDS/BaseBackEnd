using BaseBackEnd.API.ViewModel.SecutityVms.PageVms;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthorizationService : IServiceBase<ProfileModulePageFunctionality>
    {
        Task<PageAuthorizationOutputVm> GetPageAuthorizationByUserAsync(int userId, PageAuthorizationInputVm pageAuthorizationInputVm);
    }
}
