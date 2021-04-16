using BaseBackEnd.Domain.Enums;

namespace BaseBackEnd.Domain.Entities.Base
{
    public abstract class EntityAuditStatusBase : EntityAuditBase
    {
        public virtual StatusBase Status { get; set; } = StatusBase.Active;
    }
}
