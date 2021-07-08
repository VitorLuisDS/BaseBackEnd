using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Profile : EntityAuditStatusBase
    {
        public int Id { get; private set; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; private set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();
    }
}
