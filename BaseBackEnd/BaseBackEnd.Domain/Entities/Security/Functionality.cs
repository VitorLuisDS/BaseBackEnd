using BaseBackEnd.Security.Domain.Entities.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Domain.Entities.Security
{
    public class Functionality : EntityAuditStatusBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModulePageFunctionality> ModulePageFunctionalities { get; set; } = new HashSet<ModulePageFunctionality>();
    }
}
