using BaseBackEnd.Domain.Entities.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Functionality : EntityAuditStatusBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModulePageFunctionality> ModulePageFunctionalities { get; set; } = new HashSet<ModulePageFunctionality>();
    }
}
