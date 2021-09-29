using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects
{
    internal static class NameVOContracts
    {
        private const string PROPERTY_NAME = nameof(NameVO.Name);

        internal static Contract<NameVO> GetContracts(string value)
        {
            return
                new Contract<NameVO>()
                .Requires()
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(PROPERTY_NAME, value)
                    .IsGreaterOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, NameVORules.MIN_LENGTH)
                    .IsLowerOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, NameVORules.MAX_LENGTH)
                    .MatchesWithDefaultMessage(PROPERTY_NAME, value, NameVORules.ValidChars);
        }
    }
}
