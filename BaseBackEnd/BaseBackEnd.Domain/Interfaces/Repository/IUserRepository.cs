using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
    }
}
