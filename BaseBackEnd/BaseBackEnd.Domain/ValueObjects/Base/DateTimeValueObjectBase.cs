using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.ValueObjects.Base
{
    public abstract class DateTimeValueObjectBase : Notifiable<Notification>
    {
        public DateTime DateTime { get; private set; }

        private static readonly DateTime MIN_SQL_DATE = new DateTime(1753,1,1);
        public DateTimeValueObjectBase(DateTime dateTime)
        {
            DateTime = dateTime;

            AddNotifications(new Contract<DateTimeValueObjectBase>()
                .IsLowerThan(DateTime, MIN_SQL_DATE, $"{nameof(DateTime)} should be greater than {MIN_SQL_DATE}"));
        }
    }
}
