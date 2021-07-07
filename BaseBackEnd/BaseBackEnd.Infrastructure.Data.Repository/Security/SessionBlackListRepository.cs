using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security
{
    public class SessionBlackListRepository : RepositoryBase<SessionBlackList>, ISessionBlackListRepository
    {
        public SessionBlackListRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsSessionOnBlackListAsync(Guid sessionId)
        {
            return await _dbSet
                .AnyAsync(sb => sb.IdSession == sessionId);
        }
    }
}
