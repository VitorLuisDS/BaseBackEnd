using BaseBackEnd.Security.Domain.Flunt;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class DescriptionVO : ValueObjectBase
    {
        public string Description { get; private set; }

        public DescriptionVO(string description)
        {
            Description = description;

            AddNotifications(new Contract<DescriptionVO>()
                .Requires()
                    .IsLowerOrEqualThanWithDefaultMessage(nameof(Description), Description, DescriptionVORules.MAX_LENGTH));
        }
    }
}
