using BaseBackEnd.Security.Domain.Interfaces.Repository;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using BaseBackEnd.Security.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(ProjectBaseSecurityContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Session> QueryBase()
        {
            return
                Get(
                    filter: s => s.User.Status == StatusBase.Active);
        }

        public async Task<Session> AddAsync(int userId, bool stayConnected = false)
        {
            return await AddAsync(new Session
            {
                IdUser = userId,
                StayConnected = stayConnected
            });
        }

        public async Task<Session> GetSessionAndUserWithProfilesAsync(Guid sessionId)
        {
            var session = await QueryBase()
                .Include(s => s.User.UserProfiles)
                    .ThenInclude(up => up.Profile)
                .SingleOrDefaultAsync(s => s.Id == sessionId);

            if (session == default)
                return default;

            session.User.Password = default;

            return session;
        }

        public async Task<User> GetUserFromSessionIdAsync(Guid sessionId)
        {
            var session = await QueryBase()
                .Include(s => s.User)
                .SingleOrDefaultAsync(s => s.Id == sessionId);

            if (session == default)
                return default;

            var user = session.User;
            user.Password = default;
            user.Sessions = default;

            return user;
        }
    }
}
