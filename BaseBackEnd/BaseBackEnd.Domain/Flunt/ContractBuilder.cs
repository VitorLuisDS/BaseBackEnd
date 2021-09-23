using BaseBackEnd.Security.Domain.Constants;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt
{
    public static class ContractBuilder
    {
        public static Contract<T> IsNotNullOrWhiteSpaceWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsNotNullOrWhiteSpace(value, FluntContractNames.NULL_OR_WHITE_SPACES, $"{propertyName} cannot be null");
        }

        public static Contract<T> IsGreaterThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should have at least {comparer} chars");
        }

        public static Contract<T> IsLowerThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsLowerThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have no more than {comparer} chars");
        }

        public static Contract<T> IsGreaterThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should have at least {comparer} chars");
        }

        public static Contract<T> IsLowerThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .IsLowerThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have no more than {comparer} chars");
        }

        public static Contract<T> MatchesWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, string pattern) where T : ValueObjectBase
        {
            return valueObjectBase
                .Requires()
                    .Matches(value, pattern, FluntContractNames.INVALID_CHARS, $"{propertyName} should have only allowed chars");
        }
    }
}
