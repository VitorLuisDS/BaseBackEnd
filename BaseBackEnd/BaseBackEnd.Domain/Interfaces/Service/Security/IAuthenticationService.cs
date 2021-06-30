using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthenticationService : IServiceBase<User>
    {
        InvalidTokenType InvalidTokenType { get; }
        Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
        Task<TokensOutputVm> AuthenticateByTokenAsync(string token);
    }
}
