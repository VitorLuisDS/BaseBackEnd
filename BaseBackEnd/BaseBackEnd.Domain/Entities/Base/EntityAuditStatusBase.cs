using BaseBackEnd.Security.Domain.Enums;

namespace BaseBackEnd.Security.Domain.Entities.Base
{
    public abstract class EntityAuditStatusBase : EntityAuditBase
    {
        public virtual StatusBase Status { get; protected set; } = StatusBase.Active;
    }
}
