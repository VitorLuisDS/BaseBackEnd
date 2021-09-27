using BaseBackEnd.Security.Domain.Flunt;
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
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(nameof(Login), Login)
                    .IsGreaterOrEqualThanWithDefaultMessage(nameof(Login), Login, LoginVORules.MIN_LENGTH)
                    .IsLowerOrEqualThanWithDefaultMessage(nameof(Login), Login, LoginVORules.MAX_LENGTH)
                    .MatchesWithDefaultMessage(nameof(Login), Login, LoginVORules.ValidChars));
        }
    }
}
