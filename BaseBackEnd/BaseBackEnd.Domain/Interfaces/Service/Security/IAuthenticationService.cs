using BaseBackEnd.API.ViewModel.SecutityVms.TokenVms;
using BaseBackEnd.API.ViewModel.UserVms;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthenticationService : IServiceBase<User>
    {
        InvalidTokenType InvalidTokenType { get; }
        Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
        Task<TokensOutputVm> AuthenticateByTokenAsync(string token);
        Task<User> GetUserFromTokenAsync(string token);
    }
}
