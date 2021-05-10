using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface ISessionRepository : IRepositoryBase<Session>
    {
        Task<Session> AddAsync(Guid userId, bool stayConnected = false);
        Task<Session> GetSessionAndUserAsync(Guid sessionId);
    }
}
