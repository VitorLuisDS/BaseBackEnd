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

        private ICollection<Profile> _userProfiles { get; set; }
        public IReadOnlyCollection<Profile> UserProfiles { get { return _userProfiles.ToArray(); } }

        private ICollection<Session> _sessions { get; set; }
        public IReadOnlyCollection<Session> Sessions { get { return _sessions.ToArray(); } }

        public User(NameVO name, LoginVO login, PasswordVO password, Department department)
        {
            Name = name;
            Login = login;
            Password = password;
            Department = department;

            AddNotifications(name, login, password, department);
        }


        public void AddProfile(Profile profile)
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

        public void AddSession(Session session)
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

        public void SetDepartment(Department department)
        {
            if (department.IsValid)
            {
                this.Department = department;
                if(!department.Users.Contains(this))
                    department.AddUser(this);
            }
        }
    }
}
