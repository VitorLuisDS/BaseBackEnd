using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Profile : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; private set; }

        private ICollection<User> _users;
        public IReadOnlyCollection<User> Users
        {
            get
            {
                return _users?.ToArray() ?? (_users = new Collection<User>()).ToArray();
            }
        }

        private ICollection<Functionality> _functionalities;
        public IReadOnlyCollection<Functionality> Functionalities
        {
            get
            {
                return _functionalities?.ToArray() ?? (_functionalities = new Collection<Functionality>()).ToArray();
            }
        }

        public Profile(NameVO name, DescriptionVO description)
        {
            Name = name;
            Description = description;

            AddNotifications(name, description);
        }

        public void AddUser(User user)
        {
            bool userAlreadyExists = _users
                .Any(u => u.Id == user.Id);

            AddNotifications(new Contract<User>()
                .IsFalse(userAlreadyExists, $"{nameof(Profile)}.{nameof(Users)}", $"{nameof(Profile)} already has this {nameof(User)}"));

            if (IsValid)
            {
                _users.Add(user);
                if (!user.UserProfiles.Contains(this))
                    user.AddProfile(this);
            }
        }

        public void AddFunctionality(Functionality functionality)
        {
            bool functionalityAlreadyExists = _functionalities
                .Any(u => u.Id == functionality.Id);

            AddNotifications(new Contract<Functionality>()
                .IsFalse(functionalityAlreadyExists, $"{nameof(Profile)}.{nameof(Functionalities)}", $"{nameof(Profile)} already has this {nameof(Functionality)}"));

            if (IsValid)
            {
                _functionalities.Add(functionality);
                if (!functionality.UserProfiles.Contains(this))
                    functionality.AddProfile(this);
            }
        }

        public void RemoveUser(User user)
        {
            bool userExists = _users
                .Any(u => u.Id == user.Id);

            AddNotifications(new Contract<User>()
                .IsTrue(userExists, $"{nameof(Profile)}.{nameof(Users)}", $"{nameof(Profile)} does not have this {nameof(User)}"));

            if (IsValid)
            {
                _users.Remove(user);
                if (user.UserProfiles.Contains(this))
                    user.RemoveProfile(this);
            }
        }
    }
}
