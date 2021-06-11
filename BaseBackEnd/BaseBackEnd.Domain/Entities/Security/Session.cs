using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class Session
    {
        public int Id { get; set; }
        public bool? StayConnected { get; set; } = false;
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
