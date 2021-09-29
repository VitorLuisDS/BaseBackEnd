using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.RegexPatterns;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects
{
    internal static class LoginVOContracts
    {
        private const string PROPERTY_NAME = nameof(LoginVO.Login);

        internal static Contract<LoginVO> GetContracts(string value)
        {
            return
                new Contract<LoginVO>()
                .Requires()
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(PROPERTY_NAME, value)
                    .IsGreaterOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, LoginVORules.MIN_LENGTH)
                    .IsLowerOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, LoginVORules.MAX_LENGTH)
                    .MatchesWithDefaultMessage(PROPERTY_NAME, value, LoginVORules.ValidChars);
        }
    }
}
