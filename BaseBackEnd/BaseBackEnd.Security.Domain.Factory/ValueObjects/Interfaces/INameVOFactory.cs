using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces
{
    public interface INameVOFactory
    {
        NameVO CreateNameVO(string name);
    }
}