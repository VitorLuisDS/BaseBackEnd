using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.ValueObjects.Base;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class DescriptionVO : BaseValueObject
    {
        public string Description { get; private set; }

        internal DescriptionVO(string description)
        {
            Description = description;

            AddNotifications(DescriptionVOContracts.GetContracts(Description));
        }
    }
}
