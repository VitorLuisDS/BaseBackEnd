using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.ValueObjects.Base;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class LoginVO : BaseValueObject
    {
        public string Login { get; private set; }

        internal LoginVO(string login)
        {
            Login = login;

            AddNotifications(LoginVOContracts.GetContracts(Login));
        }
    }
}
