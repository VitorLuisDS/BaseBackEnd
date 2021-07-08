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
        public string Name { get; private set; }

        public NameVO(string name)
        {
            Name = name;

            AddNotifications(new Contract<NameVO>()
                .IsLowerThan(Name, 3, $"{nameof(Name)} should have at least 3 chars")
                .IsGreaterThan(Name, 50, $"{nameof(Name)} should have no more than 50 chars"));
        }
    }
}
