using BaseBackEnd.Domain.Entities.Security;
using System;

namespace BaseBackEnd.Domain.Entities.Base
{
    public abstract class EntityAuditBase
    {
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public Guid IdCreationUser { get; set; }
        public virtual User CreationUser { get; set; }
        public Guid IdLastModificationUser { get; set; }
        public virtual User LastModificationUser { get; set; }
    }
}
