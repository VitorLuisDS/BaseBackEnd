using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class LoginVO : ValueObjectBase
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 30;

        public string Login { get; private set; }

        public LoginVO(string login)
        {
            Login = login;

            AddNotifications(new Contract<LoginVO>()
                .IsLowerThan(Login, MIN_LENGTH, $"{nameof(Login)} should have at least {MIN_LENGTH} chars")
                .IsGreaterThan(Login, MAX_LENGTH, $"{nameof(Login)} should have no more than {MAX_LENGTH} chars"));
        }
    }
}
