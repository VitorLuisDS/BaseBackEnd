using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using BaseBackEnd.Security.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Page> QueryBase()
        {
            return
                Get(
                    filter: p => p.Status == StatusBase.Active);
        }

        public async Task<Page> GetPageByCodeAsync(string code)
        {
            return await QueryBase()
                .SingleAsync(p => p.Code == code);
        }
    }
}
