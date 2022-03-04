using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.ValueObjects.Base;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class PasswordVO : BaseValueObject
    {
        public string Password { get; private set; }

        internal PasswordVO(string password)
        {
            Password = password;

            AddNotifications(PasswordVOContracts.GetContracts(Password));
        }
    }
}
