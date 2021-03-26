using BaseBackEnd.Domain.Entities.Base;
using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class ProfileModulePageFunctionality : EntityAuditStatusBase
    {
        public Guid IdModule { get; set; }
        public Guid IdPage { get; set; }
        public Guid IdFunctionality { get; set; }
        public Guid IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ModulePageFunctionality ModulePageFunctionality { get; set; }
    }
}
