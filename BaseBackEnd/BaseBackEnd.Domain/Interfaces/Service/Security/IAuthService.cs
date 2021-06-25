using BaseBackEnd.Domain.Constants;
using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthService : IServiceBase<User>
    {
        InvalidTokenType InvalidTokenType { get; }
        Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
        Task<bool> ValidateToken(string token, string tokenAudience = null);
        Task<TokensOutputVm> AuthenticateByTokenAsync(string token);
    }
}
