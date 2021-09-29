using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class PasswordVO : BaseValueObject
    {
        public string Password { get; private set; }

        public PasswordVO(string password)
        {
            Password = password;

            AddNotifications(PasswordVOContracts.GetContracts(Password));
        }
    }
}
