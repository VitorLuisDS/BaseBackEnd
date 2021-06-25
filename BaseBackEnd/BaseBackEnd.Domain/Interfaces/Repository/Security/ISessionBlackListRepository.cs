using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Base;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.Repository.Security
{
    public interface ISessionBlackListRepository : IRepositoryBase<SessionBlackList>
    {
        Task<bool> IsSessionOnBlackListAsync(Guid sessionId);
    }
}
