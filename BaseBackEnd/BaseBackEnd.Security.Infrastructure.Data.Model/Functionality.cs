using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
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
