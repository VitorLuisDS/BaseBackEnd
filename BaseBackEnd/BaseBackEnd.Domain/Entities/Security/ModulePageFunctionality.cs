using BaseBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class ModulePageFunctionality : EntityAuditStatusBase
    {
        public Guid IdModule { get; set; }
        public virtual Module Module { get; set; }
        public Guid IdPage { get; set; }
        public virtual Page Page { get; set; }
        public Guid IdFunctionality { get; set; }
        public virtual Functionality Functionality { get; set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
    }
}
