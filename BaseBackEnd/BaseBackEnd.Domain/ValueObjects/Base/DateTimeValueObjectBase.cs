using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BaseBackEnd.Security.Domain.ValueObjects.Base
{
    public abstract class DateTimeValueObjectBase : Notifiable<Notification>
    {
        public DateTime DateTime { get; private set; }

        private static readonly DateTime MIN_SQL_DATE = new(1753, 1, 1);
        internal DateTimeValueObjectBase(DateTime dateTime)
        {
            DateTime = dateTime;

            AddNotifications(new Contract<DateTimeValueObjectBase>()
                .IsLowerThan(DateTime, MIN_SQL_DATE, $"{nameof(DateTime)} should be greater than {MIN_SQL_DATE}"));
        }
    }
}
