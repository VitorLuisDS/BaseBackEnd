using BaseBackEnd.Security.Domain.Entities.Base;

namespace BaseBackEnd.Security.Domain.Entities.Security
{
    public class ProfileModulePageFunctionality : EntityAuditStatusBase
    {
        public int IdModule { get; set; }
        public int IdPage { get; set; }
        public int IdFunctionality { get; set; }
        public int IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ModulePageFunctionality ModulePageFunctionality { get; set; }
    }
}
