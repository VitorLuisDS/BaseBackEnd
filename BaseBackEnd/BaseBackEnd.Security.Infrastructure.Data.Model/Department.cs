using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
{
    public class Department : EntityAuditStatusBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
