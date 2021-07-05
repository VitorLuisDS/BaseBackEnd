using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
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
