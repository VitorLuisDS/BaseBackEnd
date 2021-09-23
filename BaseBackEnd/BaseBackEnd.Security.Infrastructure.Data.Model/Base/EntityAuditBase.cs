namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels.Base
{
    public abstract class EntityAuditBase
    {
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public int IdCreationUser { get; set; }
        public virtual User CreationUser { get; set; }
        public int? IdLastModificationUser { get; set; }
        public virtual User LastModificationUser { get; set; }
    }
}
