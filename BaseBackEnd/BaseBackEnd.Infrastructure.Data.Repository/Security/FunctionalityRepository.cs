using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
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
                    filter: f => f.Status == Domain.Enums.StatusBase.Active);
        }

        public async Task<Functionality> GetFunctionalityByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(f => f.Code == code);
        }
    }
}
