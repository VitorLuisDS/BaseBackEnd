using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects;
using BaseBackEnd.Security.Infrastructure.CrossCutting.Helpers;
using Fare;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Tests.Domain.Fakes.ValueObjects
{
    public static class FakePasswordVOData
    {
        private static readonly ICollection<PasswordVO> PasswordVOs;

        static FakePasswordVOData()
        {
            PasswordVOs = CreatePasswordVOs();
        }

        private static ICollection<PasswordVO> CreatePasswordVOs()
        {
            ICollection<PasswordVO> passwordVOs = new List<PasswordVO>();

            for (int i = 0; i < 100; i++)
            {
                int randomLength      = RandomHelper.RandomIntInRange(PasswordVORules.MIN_LENGTH,PasswordVORules.MAX_LENGTH);
                string generatedLogin = RandomHelper.RandomString(randomLength);
                PasswordVO passwordVO = new(generatedLogin);

                passwordVOs.Add(passwordVO);
            }

            return passwordVOs;
        }

        public static ICollection<PasswordVO> GetPasswordVOs()
        {
            return PasswordVOs;
        }

        public static PasswordVO GetPasswordVO()
        {
            int index = RandomHelper.RandomIntInRange(0,100);

            return PasswordVOs.ElementAt(index);
        }
    }
}
