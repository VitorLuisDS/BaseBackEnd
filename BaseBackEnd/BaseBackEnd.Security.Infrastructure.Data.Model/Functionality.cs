using BaseBackEnd.Security.Infrastructure.Data.Models.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
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
