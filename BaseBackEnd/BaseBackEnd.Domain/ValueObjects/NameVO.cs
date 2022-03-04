using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.ValueObjects.Base;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class NameVO : BaseValueObject
    {
        public string Name { get; private set; }

        internal NameVO(string name)
        {
            Name = name;

            AddNotifications(NameVOContracts.GetContracts(Name));
        }
    }
}
