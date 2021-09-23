using BaseBackEnd.Security.Domain.Constants;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt
{
    public static class ContractBuilder
    {
        public static Contract<T> IsNotNullOrWhiteSpaceWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsNotNullOrWhiteSpace(propertyName, FluntContractNames.NULL_OR_WHITE_SPACES, $"{propertyName} cannot be null");
        }

        public static Contract<T> IsGreaterThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterThan(propertyName, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should have at least {comparer} chars");
        }

        public static Contract<T> IsLowerThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsLowerThan(propertyName, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have no more than {comparer} chars");
        }

        public static Contract<T> MatchesWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string pattern) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .Matches(propertyName, pattern, FluntContractNames.INVALID_CHARS, $"{propertyName} should have only allowed chars");
        }
    }
}
