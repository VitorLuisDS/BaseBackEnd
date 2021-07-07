using BaseBackEnd.Security.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using BaseBackEnd.Security.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security
{
    public class ModulePageRepository : RepositoryBase<ModulePage>, IModulePageRepository
    {
        public ModulePageRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<ModulePage> QueryBase()
        {
            return
                Get(
                    filter: mp => mp.Status == StatusBase.Active &&
                                  mp.Module.Status == StatusBase.Active &&
                                  mp.Page.Status == StatusBase.Active,
                    orderBy: null,
                    asNoTracking: true,
                    mp => mp.Module,
                    mp => mp.Page);
        }

        public async Task<ModulePage> GetModulePageByCodesAsync(string moduleCode, string pageCode)
        {
            return await QueryBase()
                .SingleAsync(mp => mp.Module.Code == moduleCode &&
                                   mp.Page.Code == pageCode);
        }
    }
}
