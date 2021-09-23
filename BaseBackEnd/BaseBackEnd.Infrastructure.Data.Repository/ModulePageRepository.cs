using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class ModulePageRepository : RepositoryBase<ModulePage>, IModulePageRepository
    {
        public ModulePageRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
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
