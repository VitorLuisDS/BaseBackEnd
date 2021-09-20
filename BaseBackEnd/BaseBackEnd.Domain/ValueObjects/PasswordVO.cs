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
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 30;
        public string Password { get; private set; }
        public PasswordVO(string password)
        {
            Password = password;

            AddNotifications(new Contract<PasswordVO>()
                .IsLowerThan(Password, MIN_LENGTH, $"{nameof(Password)} should have at least {MIN_LENGTH} chars")
                .IsGreaterThan(Password, MAX_LENGTH, $"{nameof(Password)} should have no more than {MAX_LENGTH} chars"));
        }
    }
}
