using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface IFunctionalityRepository : IRepositoryBase<Functionality>
    {
        Task<Functionality> GetFunctionalityByCodeAsync(string code);
    }
}
