using BaseBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Profile : EntityAuditStatusBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
