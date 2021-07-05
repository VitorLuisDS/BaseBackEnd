using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
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
