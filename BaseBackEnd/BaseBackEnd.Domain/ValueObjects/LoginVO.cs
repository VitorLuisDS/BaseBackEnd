using BaseBackEnd.Security.Domain.RegexPatterns;
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
                .Requires()
                    .IsNotNullOrWhiteSpace(Login, "Null or white space", $"{nameof(Login)} cannot be null")
                    .IsGreaterThan(Login, LoginVORules.MIN_LENGTH, "To short", $"{nameof(Login)} should have at least {LoginVORules.MIN_LENGTH} chars")
                    .IsLowerThan(Login, LoginVORules.MAX_LENGTH, "Too long", $"{nameof(Login)} should have no more than {LoginVORules.MAX_LENGTH} chars")
                    .Matches(Login, LoginVORules.ValidChars, "Invalid chars", $"{nameof(Login)} should have only alphabetical, number, \".\" or \"_\" chars"));
        }
    }
}
