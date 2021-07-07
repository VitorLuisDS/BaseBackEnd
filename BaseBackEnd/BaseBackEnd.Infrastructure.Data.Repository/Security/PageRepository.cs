using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Page> QueryBase()
        {
            return
                Get(
                    filter: p => p.Status == Domain.Enums.StatusBase.Active);
        }

        public async Task<Page> GetPageByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(p => p.Code == code);
        }
    }
}
