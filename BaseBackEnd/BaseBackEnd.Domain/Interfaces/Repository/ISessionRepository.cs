using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface ISessionRepository : IRepositoryBase<Session>
    {
        Task<Session> AddAsync(int userId, bool stayConnected = false);
        Task<Session> GetSessionAndUserWithProfilesAsync(Guid sessionId);
        Task<User> GetUserFromSessionIdAsync(Guid sessionId);
    }
}
