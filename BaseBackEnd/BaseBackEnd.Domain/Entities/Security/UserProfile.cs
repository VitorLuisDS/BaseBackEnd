using BaseBackEnd.Domain.Entities.Base;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class UserProfile : EntityAuditStatusBase
    {
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public int IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
