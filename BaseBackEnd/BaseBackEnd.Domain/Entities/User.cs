using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.ObjectModel;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class User : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public LoginVO Login { get; private set; }
        public PasswordVO Password { get; private set; }

        private ICollection<Profile> _userProfiles { get; set; }
        public IReadOnlyCollection<Profile> UserProfiles
        {
            get
            {
                return _userProfiles?.ToArray() ?? (_userProfiles = new Collection<Profile>()).ToArray();
            }
        }

        private ICollection<Session> _sessions { get; set; }
        public IReadOnlyCollection<Session> Sessions
        {
            get
            {
                return _sessions?.ToArray() ?? (_sessions = new Collection<Session>()).ToArray();
            }
        }

        public User(NameVO name, LoginVO login, PasswordVO password)
        {
            Name = name;
            Login = login;
            Password = password;

            AddNotifications(name, login, password);
        }


        public void AddProfile(Profile profile)
        {
            if (profile is not null)
            {
                var profileAlreadyExists = _userProfiles
                    .Any(up => up.Id == profile.Id);

                AddNotifications(new Contract<User>()
                    .IsFalse(profileAlreadyExists, $"{nameof(User)}.{nameof(UserProfiles)}", $"{nameof(User)} already has this {nameof(Profile)}"));

                if (IsValid)
                {
                    _userProfiles.Add(profile);

                    if (!profile.Users.Contains(this))
                        profile.AddUser(this);
                }
            }
        }

        public void AddSession(Session session)
        {
            if (session is not null)
            {
                var sessionAlreadyExists = _sessions
                    .Any(up => up.Id == session.Id);

                AddNotifications(new Contract<Session>()
                    .IsFalse(sessionAlreadyExists, $"{nameof(User)}.{nameof(Sessions)}", $"{nameof(User)} already has this {nameof(Session)}"));

                if (IsValid)
                {
                    _sessions.Add(session);

                    if (session.User != this)
                        session.SetUser(this);
                }
            }
        }
    }
}
