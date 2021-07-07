using System;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class SessionBlackList
    {
        public Guid Id { get; set; }
        public Guid IdSession { get; set; }
        public virtual Session Session { get; set; }
    }
}
