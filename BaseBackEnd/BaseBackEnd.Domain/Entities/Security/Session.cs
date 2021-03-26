using BaseBackEnd.Domain.Entities.Base;
using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Session : EntityBase
    {
        public bool? KeepConected { get; set; } = false;
        public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
