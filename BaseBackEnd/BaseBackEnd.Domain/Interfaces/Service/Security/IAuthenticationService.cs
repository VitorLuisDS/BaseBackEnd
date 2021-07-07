using BaseBackEnd.Security.Domain.Entities.Security;
using BaseBackEnd.Security.Domain.Enums;
using BaseBackEnd.Security.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Service.Security
{
    public interface IAuthenticationService : IServiceBase<User>
    {
        InvalidTokenType InvalidTokenType { get; }
        Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
        Task<TokensOutputVm> AuthenticateByTokenAsync(string token);
        Task<User> GetUserFromTokenAsync(string token);
    }
}
