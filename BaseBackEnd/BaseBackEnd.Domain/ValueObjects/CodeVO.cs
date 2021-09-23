using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class CodeVO : ValueObjectBase
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 50;

        public string Code { get; private set; }

        public CodeVO(string code)
        {
            Code = code;

            AddNotifications(new Contract<CodeVO>()
                .NotMatches(Code, @"/^[a-zA-Z\-]{0,}$/g", $"{nameof(Code)} should have only alphabetical and '-' chars")
                .IsLowerThan(Code, MIN_LENGTH, $"{nameof(Code)} should have at least {MIN_LENGTH} chars")
                .IsGreaterThan(Code, MAX_LENGTH, $"{nameof(Code)} should have no more than {MAX_LENGTH} chars"));
        }
    }
}
