﻿using BaseBackEnd.Security.Infrastructure.Data.Models.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
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
