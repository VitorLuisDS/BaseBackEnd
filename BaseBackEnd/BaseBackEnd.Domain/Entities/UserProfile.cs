using BaseBackEnd.Security.Domain.Entities.Base;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class UserProfile : EntityAuditStatusBase
    {
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public int IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
