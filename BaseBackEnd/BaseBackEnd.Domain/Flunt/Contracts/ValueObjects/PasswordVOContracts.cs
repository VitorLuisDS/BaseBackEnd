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
    internal static class PasswordVOContracts
    {
        private const string PROPERTY_NAME = nameof(PasswordVO.Password);

        internal static Contract<PasswordVO> GetContracts(string value)
        {
            return
                new Contract<PasswordVO>()
                .Requires()
                    .IsNotNullOrWhiteSpaceWithDefaultMessage(PROPERTY_NAME, value)
                    .IsGreaterOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, PasswordVORules.MIN_LENGTH)
                    .IsLowerOrEqualThanWithDefaultMessage(PROPERTY_NAME, value, PasswordVORules.MAX_LENGTH);
        }
    }
}
