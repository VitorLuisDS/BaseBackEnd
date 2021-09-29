using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.RegexPatterns;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class LoginVO : BaseValueObject
    {
        public string Login { get; private set; }

        public LoginVO(string login)
        {
            Login = login;

            AddNotifications(LoginVOContracts.GetContracts(Login));
        }
    }
}
