using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class NameVO : ValueObjectBase
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 50;

        public string Name { get; private set; }

        public NameVO(string name)
        {
            Name = name;

            AddNotifications(new Contract<NameVO>()
                .IsLowerThan(Name, MIN_LENGTH, $"{nameof(Name)} should have at least {MIN_LENGTH} chars")
                .IsGreaterThan(Name, MAX_LENGTH, $"{nameof(Name)} should have no more than {MAX_LENGTH} chars"));
        }
    }
}
