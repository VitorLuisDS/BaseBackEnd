using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
    }
}
