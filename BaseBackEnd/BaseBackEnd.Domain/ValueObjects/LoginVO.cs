using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class LoginVO : ValueObjectBase
    {
        public string Login { get; private set; }

        public LoginVO(string login)
        {
            Login = login;

            AddNotifications(new Contract<LoginVO>()
                .IsLowerThan(Login, 3, $"{nameof(Login)} should have at least 3 chars")
                .IsGreaterThan(Login, 30, $"{nameof(Login)} should have no more than 30 chars"));
        }
    }
}
