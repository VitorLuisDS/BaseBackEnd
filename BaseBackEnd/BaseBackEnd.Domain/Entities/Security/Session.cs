using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Session
    {
        public Guid Id { get; set; }
        public bool? KeepConnected { get; set; } = false;
        public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
