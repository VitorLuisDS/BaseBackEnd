using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
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
                    filter: mp => mp.Status == Domain.Enums.StatusBase.Active &&
                                  mp.Module.Status == Domain.Enums.StatusBase.Active &&
                                  mp.Page.Status == Domain.Enums.StatusBase.Active,
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
