using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
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
