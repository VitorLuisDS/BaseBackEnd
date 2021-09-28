using Flunt.Notifications;
using System;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class SessionBlackList : Notifiable<Notification>
    {
        public Guid Id { get; }
        public Session Session { get; private set; }

        public SessionBlackList(Session session)
        {
            Session = session;
        }

        public void SetSession(Session session)
        {
            if (session.IsValid)
            {
                this.Session = session;
                if (session.SessionBlackList != this)
                    session.SetSessionBlackList(this);
            }
        }
    }
}
