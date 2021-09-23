using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class DescriptionVO : ValueObjectBase
    {
        private const int MAX_LENGTH = 100;

        public string Description { get; private set; }

        public DescriptionVO(string description)
        {
            Description = description;

            AddNotifications(new Contract<DescriptionVO>()
                .IsGreaterThan(Description, MAX_LENGTH, $"{nameof(Description)} should have no more than {MAX_LENGTH} chars"));
        }
    }
}
