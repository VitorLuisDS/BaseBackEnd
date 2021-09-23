using BaseBackEnd.Security.Domain.Constants;
using BaseBackEnd.Security.Domain.Flunt;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

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
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(nameof(Name), Name)
                    .IsGreaterThanWithDefaultMessage(nameof(Name), Name, NameVORules.MIN_LENGTH)
                    .IsLowerThanWithDefaultMessage(nameof(Name), Name, NameVORules.MAX_LENGTH)
                    .MatchesWithDefaultMessage(nameof(Name), Name, NameVORules.ValidChars));
        }
    }
}
