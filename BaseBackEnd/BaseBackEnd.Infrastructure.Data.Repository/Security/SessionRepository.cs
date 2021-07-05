using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Session> QueryBase()
        {
            return
                Get(
                    filter: s => s.User.Status == Domain.Enums.StatusBase.Active);
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
