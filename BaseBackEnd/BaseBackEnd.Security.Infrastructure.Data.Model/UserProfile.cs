using BaseBackEnd.Security.Infrastructure.Data.Models.Base;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
{
    public class UserProfile : EntityAuditStatusBase
    {
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public int IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
