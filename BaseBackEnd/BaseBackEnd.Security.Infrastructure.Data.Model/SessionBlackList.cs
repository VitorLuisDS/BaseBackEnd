﻿namespace BaseBackEnd.Security.Infrastructure.Data.PersistenceModels
{
    public class SessionBlackList
    {
        public Guid Id { get; set; }
        public Guid IdSession { get; set; }
        public virtual Session Session { get; set; }
    }
}
