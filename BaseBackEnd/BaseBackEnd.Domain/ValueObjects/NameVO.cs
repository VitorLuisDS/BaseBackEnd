using BaseBackEnd.Security.Domain.Rules;
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
                .Requires()
                    .IsNotNullOrWhiteSpace(Name, "Null or white space", $"{nameof(Name)} cannot be null")
                    .IsGreaterThan(Name, NameVORules.MIN_LENGTH, "To short", $"{nameof(Name)} should have at least {NameVORules.MIN_LENGTH} chars")
                    .IsLowerThan(Name, NameVORules.MAX_LENGTH, "Too long", $"{nameof(Name)} should have no more than {NameVORules.MAX_LENGTH} chars")
                    .Matches(Name, NameVORules.ValidChars, "Invalid chars", $"{nameof(Name)} should have only alphabetical or \"'\" chars"));
        }
    }
}
