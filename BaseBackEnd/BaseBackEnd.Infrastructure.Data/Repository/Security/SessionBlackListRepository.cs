using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
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
