using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class DescriptionVO : BaseValueObject
    {
        public string Description { get; private set; }

        public DescriptionVO(string description)
        {
            Description = description;

            AddNotifications(DescriptionVOContracts.GetContracts(Description));
        }
    }
}
