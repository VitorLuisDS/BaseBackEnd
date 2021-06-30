using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface IFunctionalityRepository : IRepositoryBase<Functionality>
    {
        Task<Functionality> GetFunctionalityByCodeAsync(string code);
    }
}
