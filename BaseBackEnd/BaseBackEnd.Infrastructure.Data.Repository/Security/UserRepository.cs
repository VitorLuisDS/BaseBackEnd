using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Infrastructure.CrossCutting.Cryptography;
using BaseBackEnd.Infrastructure.Data.Context;
using BaseBackEnd.Infrastructure.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.Repository.Security
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<User> QueryBase()
        {
            return Get(
                filter: u => u.Status == Domain.Enums.StatusBase.Active);
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            string cryptPassword = GenerateMD5.Get(password);
            var user = await QueryBase()
                .Include(u => u.UserProfiles)
                    .ThenInclude(up => up.Profile)
                .SingleOrDefaultAsync(u => u.Login == login &&
                                           u.Password == cryptPassword);

            if (user != default)
                user.Password = default;

            return user;
        }
    }
}
