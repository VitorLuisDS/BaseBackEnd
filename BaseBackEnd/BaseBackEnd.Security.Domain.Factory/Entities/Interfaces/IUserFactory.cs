using BaseBackEnd.Security.Domain.Entities;

namespace BaseBackEnd.Security.Domain.Factory.Entities.Interfaces
{
    public interface IUserFactory
    {
        User CreateUser(string name, string login, string password);
    }
}