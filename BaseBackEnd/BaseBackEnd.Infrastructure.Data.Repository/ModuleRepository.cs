using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Module> QueryBase()
        {
            return
                Get(
                    filter: m => m.Status == StatusBase.Active);
        }

        public async Task<Module> GetModuleByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(m => m.Code == code);
        }
    }
}
