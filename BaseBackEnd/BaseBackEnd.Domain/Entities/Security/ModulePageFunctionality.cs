using BaseBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class ModulePageFunctionality : EntityAuditStatusBase
    {
        public Guid IdModulePage { get; set; }
        public virtual ModulePage ModulePage { get; set; }
        public Guid IdPage { get; set; }
        public Guid IdFunctionality { get; set; }
        public virtual Functionality Functionality { get; set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
    }
}
