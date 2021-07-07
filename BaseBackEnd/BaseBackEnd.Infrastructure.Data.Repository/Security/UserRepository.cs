using BaseBackEnd.Security.Domain.Interfaces.Repository.Security;
using BaseBackEnd.Security.Infrastructure.CrossCutting.Cryptography;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Base;
using BaseBackEnd.Security.Infrastructure.Data.Models;
using BaseBackEnd.Security.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.Repositories.Security
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectBaseContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<User> QueryBase()
        {
            return Get(
                filter: u => u.Status == StatusBase.Active);
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
