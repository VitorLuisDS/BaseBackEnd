using System;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class SessionBlackList
    {
        public Guid Id { get; set; }
        public Guid IdSession { get; set; }
        public virtual Session Session { get; set; }
    }
}
