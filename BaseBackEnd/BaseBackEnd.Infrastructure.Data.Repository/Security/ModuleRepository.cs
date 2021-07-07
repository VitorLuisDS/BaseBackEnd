using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Module> QueryBase()
        {
            return
                Get(
                    filter: m => m.Status == Domain.Enums.StatusBase.Active);
        }

        public async Task<Module> GetModuleByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(m => m.Code == code);
        }
    }
}
