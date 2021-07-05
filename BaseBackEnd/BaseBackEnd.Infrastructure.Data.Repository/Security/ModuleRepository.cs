using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
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
