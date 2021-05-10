using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Domain.ViewModels.UserVms;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using BaseBackEnd.Infrastructure.Util.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> AuthenticateAsync(UserAuthInputVm userAuthInputVm)
        {
            string cryptPassword = GenerateMD5.Get(userAuthInputVm.Password);
            return await _dbSet
                .Include(x => x.Profile)
                    .ThenInclude(x => x.ProfileModulePageFunctionalities)
                .FirstOrDefaultAsync(x => x.Password == cryptPassword);
        }
    }
}
