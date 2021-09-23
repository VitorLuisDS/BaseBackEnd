using Flunt.Notifications;

namespace BaseBackEnd.Security.Domain.Entities.Base
{
    public abstract class EntityAuditBase : Notifiable<Notification>
    {
        public DateTime CreationDate { get; protected set; }
        public DateTime? LastModificationDate { get; protected set; }
        public User CreationUser { get; protected set; }
        public User LastModificationUser { get; protected set; }
    }
}
