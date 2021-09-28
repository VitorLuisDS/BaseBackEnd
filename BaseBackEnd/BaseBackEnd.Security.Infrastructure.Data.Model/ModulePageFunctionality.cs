using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
{
    public class ModulePageFunctionality : EntityAuditStatusBase
    {
        public int IdModule { get; set; }
        public virtual ModulePage ModulePage { get; set; }
        public int IdPage { get; set; }
        public int IdFunctionality { get; set; }
        public virtual Functionality Functionality { get; set; }
        public virtual ICollection<ProfileModulePageFunctionality> ProfileModulePageFunctionalities { get; set; } = new HashSet<ProfileModulePageFunctionality>();
    }
}
