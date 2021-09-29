using BaseBackEnd.Security.Domain.Flunt.Base;
using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Flunt.Contracts.ValueObjects
{
    internal static class DescriptionVOContracts
    {
        private const string PROPERTY_NAME = nameof(DescriptionVO.Description);

        internal static Contract<DescriptionVO> GetContracts(string value)
        {
            return
                new Contract<DescriptionVO>()
                .Requires()
                    .IsLowerOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, DescriptionVORules.MAX_LENGTH);
        }
    }
}
