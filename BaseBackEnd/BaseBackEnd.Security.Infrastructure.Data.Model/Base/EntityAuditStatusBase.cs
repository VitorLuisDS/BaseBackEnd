using BaseBackEnd.Security.Infrastructure.Data.Models.Enums;

namespace BaseBackEnd.Security.Infrastructure.Data.Models.Base
{
    public abstract class EntityAuditStatusBase : EntityAuditBase
    {
        public virtual StatusBase Status { get; set; } = StatusBase.Active;
    }
}
