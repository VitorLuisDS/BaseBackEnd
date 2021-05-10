﻿using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Session> AddAsync(Guid userId, bool stayConnected = false)
        {
            return await AddAsync(new Session
            {
                IdUser = userId,
                StayConnected = stayConnected
            });
        }

        public async Task<Session> GetSessionAndUserAsync(Guid sessionId)
        {
            var session = await _dbSet
                .Include(x => x.User)
                    .ThenInclude(x => x.Profile)
                        .ThenInclude(x => x.ProfileModulePageFunctionalities)
                .FirstOrDefaultAsync(x => x.Id == sessionId);
            return session;
        }
    }
}