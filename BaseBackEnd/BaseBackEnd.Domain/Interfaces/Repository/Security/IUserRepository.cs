using BaseBackEnd.Security.Domain.Entities.Security;
using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository.Security
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
    }
}
