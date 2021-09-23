using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using Microsoft.EntityFrameworkCore;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class SessionBlackListRepository : RepositoryBase<SessionBlackList>, ISessionBlackListRepository
    {
        public SessionBlackListRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsSessionOnBlackListAsync(Guid sessionId)
        {
            return await _dbSet
                .AnyAsync(sb => sb.IdSession == sessionId);
        }
    }
}
