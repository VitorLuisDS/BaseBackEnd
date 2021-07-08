using BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Enums;

namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base
{
    public abstract class EntityAuditStatusBase : EntityAuditBase
    {
        public virtual StatusBase Status { get; set; } = StatusBase.Active;
    }
}
