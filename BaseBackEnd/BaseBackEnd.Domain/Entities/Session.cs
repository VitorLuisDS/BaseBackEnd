using Flunt.Notifications;
using System;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Session : Notifiable<Notification>
    {
        public Guid Id { get; }
        public bool? StayConnected { get; private set; }
        public User User { get; private set; }
        public SessionBlackList SessionBlackList { get; private set; }

        public Session(bool? stayConnected, User user)
        {
            StayConnected = stayConnected;
            User = user;

            AddNotifications(user);
        }

        public void SetUser(User user)
        {
            if (user.IsValid)
            {
                this.User = user;
                if (!user.Sessions.Contains(this))
                    user.AddSession(this);
            }
        }

        public void SetSessionBlackList(SessionBlackList sessionBlackList)
        {
            if (sessionBlackList.IsValid)
            {
                this.SessionBlackList = sessionBlackList;
                if (sessionBlackList.Session != this)
                    sessionBlackList.SetSession(this);
            }
        }
    }
}
