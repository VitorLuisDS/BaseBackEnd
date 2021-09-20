using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Department : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; set; }

        private ICollection<User> _users { get; set; }
        public IReadOnlyCollection<User> Users { get { return _users.ToArray(); } }

        public Department(NameVO name, DescriptionVO description)
        {
            Name = name;
            Description = description;

            AddNotifications(name, description);
        }

        public void AddUser(User user)
        {
            var userAlreadyExists = _users
                .Any(u => u.Id == user.Id);

            AddNotifications(new Contract<User>()
                .IsFalse(userAlreadyExists, $"{nameof(Department)}.{nameof(Users)}", $"{nameof(Department)} already has this {nameof(User)}"));

            if (IsValid)
            {
                _users.Add(user);
                if (user.Department != this)
                    user.SetDepartment(this);
            }
        }
    }
}
