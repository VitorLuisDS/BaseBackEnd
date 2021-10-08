using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class User : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public LoginVO Login { get; private set; }
        public PasswordVO Password { get; private set; }

        private ICollection<Profile> _userProfiles;
        public IReadOnlyCollection<Profile> UserProfiles
        {
            get
            {
                return _userProfiles?.ToArray() ?? (_userProfiles = new Collection<Profile>()).ToArray();
            }
        }

        private ICollection<Session> _sessions;
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

            AddNotifications(name ?? new(default),
                             login ?? new(default),
                             password ?? new(default));
        }


        public void AddProfile(Profile profile)
        {
            if (profile is not null)
            {
                bool profileAlreadyExists = UserProfiles
                    .Any(up => up.Id == profile.Id);

                if (!profileAlreadyExists)
                {
                    _userProfiles.Add(profile);

                    if (!profile.Users.Contains(this))
                        profile.AddUser(this);
                }
            }
        }

        public void RemoveProfile(Profile profile)
        {
            if (profile.Id != default && profile.Id > uint.MinValue)
            {
                bool profileExists = UserProfiles
                    .Any(up => up.Id == profile.Id);

                if (profileExists)
                {
                    _userProfiles.Remove(profile);

                    if (profile.Users.Contains(this))
                        profile.RemoveUser(this);
                }
            }
        }

        public void AddSession(Session session)
        {
            if (session is not null)
            {
                bool sessionAlreadyExists = Sessions
                    .Any(up => up.Id == session.Id);

                if (!sessionAlreadyExists)
                {
                    _sessions.Add(session);

                    if (session.User != this)
                        session.SetUser(this);
                }
            }
        }
    }
}
