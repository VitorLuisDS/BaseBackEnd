using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects
{
    public class PasswordVOFactory : IPasswordVOFactory
    {
        public PasswordVO CreatePasswordVO(string password)
        {
            PasswordVO passwordVO = new(password);
            return passwordVO;
        }
    }
}
