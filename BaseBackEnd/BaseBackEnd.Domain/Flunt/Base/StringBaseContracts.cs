using BaseBackEnd.Security.Domain.Constants;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt.Base
{
    internal static class StringBaseContracts
    {
        public static Contract<T> IsNotNullOrWhiteSpaceWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsNotNullOrWhiteSpace(value, FluntContractNames.NULL_OR_WHITE_SPACES, $"{propertyName} cannot be null");
        }

        public static Contract<T> IsGreaterThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should more than {comparer} chars");
        }

        public static Contract<T> IsLowerThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsLowerThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should less than {comparer} chars");
        }

        public static Contract<T> IsGreaterOrEqualThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterOrEqualsThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should have at least {comparer} chars");
        }

        public static Contract<T> IsLowerOrEqualThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsLowerOrEqualsThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have no more than {comparer} chars");
        }

        public static Contract<T> MatchesWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, string value, string pattern) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .Matches(value, pattern, FluntContractNames.INVALID_CHARS, $"{propertyName} should have only allowed chars");
        }
    }
}
