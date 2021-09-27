using BaseBackEnd.Security.Domain.Flunt;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class CodeVO : ValueObjectBase
    {
        public string Code { get; private set; }

        public CodeVO(string code)
        {
            Code = code;

            AddNotifications(new Contract<CodeVO>()
                .IsNotNullOrWhiteSpaceWithDefaultMessage(nameof(Code), Code)
                .IsGreaterOrEqualThanWithDefaultMessage(nameof(Code), Code, CodeVORules.MIN_LENGTH)
                .IsLowerOrEqualThanWithDefaultMessage(nameof(Code), Code, CodeVORules.MAX_LENGTH)
                .MatchesWithDefaultMessage(nameof(Code), Code, CodeVORules.VALID_CHARS));
        }
    }
}
