using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Domain.ViewModels.UserVms;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> AuthenticateAsync(UserAuthInputVm userAuthInputVm);
    }
}
