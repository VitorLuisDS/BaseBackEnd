using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces
{
    public interface IPasswordVOFactory
    {
        PasswordVO CreatePasswordVO(string password);
    }
}