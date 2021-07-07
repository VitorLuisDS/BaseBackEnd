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
    public class FunctionalityRepository : RepositoryBase<Functionality>, IFunctionalityRepository
    {
        public FunctionalityRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Functionality> QueryBase()
        {
            return
                Get(
                    filter: f => f.Status == StatusBase.Active);
        }

        public async Task<Functionality> GetFunctionalityByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(f => f.Code == code);
        }
    }
}
