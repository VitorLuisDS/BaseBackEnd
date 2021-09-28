using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects
{
    public class NameVOFactory : INameVOFactory
    {
        public NameVO CreateNameVO(string name)
        {
            NameVO nameVo = new(name);
            return nameVo;
        }
    }
}
