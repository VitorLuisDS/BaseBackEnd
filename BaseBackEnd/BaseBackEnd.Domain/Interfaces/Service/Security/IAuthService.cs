using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Service.Base;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Service.Security
{
    public interface IAuthService : IServiceBase<User>
    {
        Exception ValidationExceptionType { get; }
        Task<TokensOutputVm> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
        bool ValidateToken(string token, string tokenAudience = null);
        Task<TokensOutputVm> AuthenticateByTokenAsync(string token);
    }
}
