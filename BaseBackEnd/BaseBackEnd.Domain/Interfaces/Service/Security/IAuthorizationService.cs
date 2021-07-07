using BaseBackEnd.Security.Domain.Entities.Security;
using BaseBackEnd.Security.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Service.Security
{
    public interface IAuthorizationService : IServiceBase<ProfileModulePageFunctionality>
    {
        Task<PageAuthorizationOutputVm> GetPageAuthorizationByUserAsync(int userId, PageAuthorizationInputVm pageAuthorizationInputVm);
    }
}
