using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class User : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public LoginVO Login { get; private set; }
        public PasswordVO Password { get; private set; }
        public Department Department { get; private set; }

        private ICollection<UserProfile> _userProfiles { get; set; }
        public IReadOnlyCollection<UserProfile> UserProfiles { get { return _userProfiles.ToArray(); } }

        public User(NameVO name, LoginVO login, PasswordVO password, Department department)
        {
            Name = name;
            Login = login;
            Password = password;
            Department = department;

            AddNotifications(name, login, password, department);
        }


        public void AddProfile(UserProfile userProfile)
        {
            var profileAlreadyExists = _userProfiles
                .Any(up => up.Profile.Id == userProfile.Profile.Id);

            AddNotifications(new Contract<User>()
                .IsFalse(profileAlreadyExists, $"{nameof(User)}.{nameof(UserProfiles)}", $"{nameof(User)} already has this profile"));

            if (IsValid)
                _userProfiles.Add(userProfile);
        }
    }
}
