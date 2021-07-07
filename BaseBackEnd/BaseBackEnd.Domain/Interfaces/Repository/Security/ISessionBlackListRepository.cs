using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository.Security
{
    public interface ISessionBlackListRepository : IRepositoryBase<SessionBlackList>
    {
        Task<bool> IsSessionOnBlackListAsync(Guid sessionId);
    }
}
