using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
{
    public class UserProfile : EntityAuditStatusBase
    {
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public int IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
