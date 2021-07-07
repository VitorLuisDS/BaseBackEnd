﻿using BaseBackEnd.Security.Infrastructure.Data.Models.Base;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.Data.Models
{
    public class User : EntityAuditStatusBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdDepartment { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();
    }
}
