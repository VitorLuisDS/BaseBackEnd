using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Module> GetModuleByCodeAsync(string code)
        {
            return await _dbSet.SingleAsync(c => c.Code == code && c.Status == Domain.Enums.StatusBase.Active);
        }
    }
}
