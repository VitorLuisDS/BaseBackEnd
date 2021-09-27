using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects
{
    public class LoginVOFactory : ILoginVOFactory
    {
        public LoginVO CreateLoginVO(string login)
        {
            LoginVO loginVo = new LoginVO(login);
            return loginVo;
        }
    }
}
