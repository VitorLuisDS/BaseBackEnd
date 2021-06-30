using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class ModulePageRepository : RepositoryBase<ModulePage>, IModulePageRepository
    {
        public ModulePageRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<ModulePage> GetModulePageByCodesAsync(string moduleCode, string pageCode)
        {
            return await _dbSet
                .Include(m => m.Module)
                .Include(m => m.Page)
                .SingleAsync(m => m.Module.Code == moduleCode && 
                                  m.Page.Code == pageCode &&
                                  m.Module.Status == Domain.Enums.StatusBase.Active &&
                                  m.Page.Status == Domain.Enums.StatusBase.Active &&
                                  m.Status == Domain.Enums.StatusBase.Active);
        }
    }
}
