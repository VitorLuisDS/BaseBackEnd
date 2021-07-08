using BaseBackEnd.Security.Domain.Entities.Base;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class UserProfile : EntityAuditStatusBase
    {
        public User User { get; private set; }
        public Profile Profile { get; private set; }

        public UserProfile(User user, Profile profile)
        {
            User = user;
            Profile = profile;

            AddNotifications(user, profile);
        }
    }
}
