using BaseBackEnd.Security.Domain.Interfaces.Repository.Base;
using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels;

namespace BaseBackEnd.Security.Domain.Interfaces.Repository
{
    public interface ISessionBlackListRepository : IRepositoryBase<SessionBlackList>
    {
        Task<bool> IsSessionOnBlackListAsync(Guid sessionId);
    }
}
