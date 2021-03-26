using BaseBackEnd.Domain.Entities.Base;
using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class ProfileModulePageFunctionality : EntityAuditStatusBase
    {
        public Guid IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
        public Guid IdModulePageFunctionality { get; set; }
        public virtual ModulePageFunctionality ModulePageFunctionality { get; set; }
    }
}
