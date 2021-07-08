using BaseBackEnd.Security.Domain.ValueObjects.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.ValueObjects
{
    public class DescriptionVO : ValueObjectBase
    {
        public string Description { get; private set; }

        public DescriptionVO(string description)
        {
            Description = description;

            AddNotifications(new Contract<DescriptionVO>()
                .IsGreaterThan(Description, 100, $"{nameof(Description)} should have no more than 100 chars"));
        }
    }
}
