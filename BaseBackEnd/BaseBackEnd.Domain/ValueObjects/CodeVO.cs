using BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects;
using BaseBackEnd.Security.Domain.ValueObjects.Base;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class CodeVO : BaseValueObject
    {
        public string Code { get; private set; }

        public CodeVO(string code)
        {
            Code = code;

            AddNotifications(CodeVOContracts.GetContracts(Code));
        }
    }
}
