using BaseBackEnd.Security.Domain.Flunt;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class PasswordVO : ValueObjectBase
    {
        public string Password { get; private set; }
        public PasswordVO(string password)
        {
            Password = password;

            AddNotifications(new Contract<PasswordVO>()
                .IsNotNullOrWhiteSpaceWithDefaultMessage(nameof(Password), Password)
                .IsGreaterOrEqualThanWithDefaultMessage(nameof(Password), Password, PasswordVORules.MIN_LENGTH)
                .IsLowerOrEqualThanWithDefaultMessage(nameof(Password), Password, PasswordVORules.MAX_LENGTH));
        }
    }
}
