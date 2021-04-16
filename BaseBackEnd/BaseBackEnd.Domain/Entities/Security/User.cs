using BaseBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BaseBackEnd.Domain.Entities.Security
{
    public class User : EntityAuditStatusBase
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid IdProfile { get; set; }
        public virtual Profile Profile { get; set; }
        public Guid IdDepartment { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }
}
