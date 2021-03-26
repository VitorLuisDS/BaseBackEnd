using BaseBackEnd.Domain.Entities.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Department : EntityAuditStatusBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
