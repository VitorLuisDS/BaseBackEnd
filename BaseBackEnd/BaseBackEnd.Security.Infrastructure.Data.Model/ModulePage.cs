﻿using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
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