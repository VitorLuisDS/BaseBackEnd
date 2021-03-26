using BaseBackEnd.Domain.Entities.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Module : EntityAuditStatusBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModulePage> ModulePages { get; set; } = new HashSet<ModulePage>();
    }
}
