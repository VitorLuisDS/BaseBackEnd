using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class PasswordVO : ValueObjectBase
    {

        public string Password { get; private set; }
        public PasswordVO(string password)
        {
            Password = password;

            AddNotifications(new Contract<PasswordVO>()
                .IsLowerThan(Password, 3, $"{nameof(Password)} should have at least 3 chars")
                .IsGreaterThan(Password, 30, $"{nameof(Password)} should have no more than 30 chars"));
        }
    }
}
