using BaseBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class ModulePage : EntityAuditStatusBase
    {
        public int IdModule { get; set; }
        public virtual Module Module { get; set; }
        public int IdPage { get; set; }
        public virtual Page Page { get; set; }
        public virtual ICollection<ModulePageFunctionality> ModulePageFunctionalities { get; set; } = new HashSet<ModulePageFunctionality>();
    }
}
