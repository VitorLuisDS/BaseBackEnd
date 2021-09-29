using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects
{
    internal static class CodeVOContracts
    {
        private const string PROPERTY_NAME = nameof(CodeVO.Code);

        internal static Contract<CodeVO> GetContracts(string value)
        {
            return
                new Contract<CodeVO>()
                .Requires()
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(PROPERTY_NAME, value)
                    .IsGreaterOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, CodeVORules.MIN_LENGTH)
                    .IsLowerOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, CodeVORules.MAX_LENGTH)
                    .MatchesWithDefaultMessage(PROPERTY_NAME, value, CodeVORules.VALID_CHARS);
        }
    }
}
