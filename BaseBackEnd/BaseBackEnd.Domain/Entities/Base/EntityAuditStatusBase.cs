using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Domain.Enums;
using System;

namespace BaseBackEnd.Domain.Entities.Base
{
    public abstract class EntityAuditStatusBase : EntityAuditBase
    {
        public virtual StatusBase Status { get; set; } = StatusBase.Active;
    }
}
