using BaseBackEnd.Security.Domain.Constants;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt.Base
{
    internal static class IntegerBaseContracts
    {
        public static Contract<T> IsGreaterThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should more than {comparer} chars");
        }

        public static Contract<T> IsLowerThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsLowerThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have less than {comparer} chars");
        }

        public static Contract<T> IsGreaterOrEqualThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsGreaterOrEqualsThan(value, comparer, FluntContractNames.TOO_SHORT, $"{propertyName} should have at least {comparer} chars");
        }

        public static Contract<T> IsLowerOrEqualThanWithDefaultMessage<T>(this Contract<T> valueObjectBase, string propertyName, int value, int comparer) where T : BaseValueObject
        {
            return valueObjectBase
                .Requires()
                    .IsLowerOrEqualsThan(value, comparer, FluntContractNames.TOO_LONG, $"{propertyName} should have no more than {comparer} chars");
        }
    }
}
