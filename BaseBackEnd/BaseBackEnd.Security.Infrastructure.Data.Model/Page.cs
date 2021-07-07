using BaseBackEnd.Security.Infrastructure.Data.Models.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
{
    public class Page : EntityAuditStatusBase
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModulePage> ModulePages { get; set; } = new HashSet<ModulePage>();
    }
}
