using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class CodeVO : ValueObjectBase
    {
        public string Code { get; private set; }

        public CodeVO(string code)
        {
            Code = code;

            AddNotifications(new Contract<CodeVO>()
                .NotMatches(Code, @"/^[a-zA-Z\-]{0,}$/g", $"{nameof(Code)} should have only alphabetical and '-' chars")
                .IsLowerThan(Code, 3, $"{nameof(Code)} should have at least 3 chars")
                .IsGreaterThan(Code, 50, $"{nameof(Code)} should have no more than 50 chars"));
        }
    }
}
