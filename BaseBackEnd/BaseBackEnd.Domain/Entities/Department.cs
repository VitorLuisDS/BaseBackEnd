using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Department : EntityAuditStatusBase
    {
        public int Id { get; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; set; }

        private ICollection<Profile> _profiles { get; set; }
        public IReadOnlyCollection<Profile> Profiles { get { return _profiles.ToArray(); } }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
