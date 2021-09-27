using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces
{
    public interface ILoginVOFactory
    {
        LoginVO CreateLoginVO(string login);
    }
}