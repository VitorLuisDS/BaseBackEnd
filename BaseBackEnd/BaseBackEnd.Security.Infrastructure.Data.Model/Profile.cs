using BaseBackEnd.Security.Infrastructure.Data.Models.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
{
    public class Profile : EntityAuditStatusBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();
    }
}
