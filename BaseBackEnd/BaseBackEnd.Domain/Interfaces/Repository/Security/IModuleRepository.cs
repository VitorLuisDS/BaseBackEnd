using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository.Security
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        Task<Module> GetModuleByCodeAsync(string code);
    }
}
