﻿using BaseBackEnd.Security.Domain.RegexPatterns;
using BaseBackEnd.Security.Domain.ValueObjects;
using Fare;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Tests.Domain.Fakes.ValueObjects
{
    public static class FakeLoginVOData
    {
        private static readonly ICollection<LoginVO> LoginVOs;

        static FakeLoginVOData()
        {
            LoginVOs = CreateLoginVOs();
        }

        private static ICollection<LoginVO> CreateLoginVOs()
        {
            ICollection<LoginVO> loginVOs = new List<LoginVO>();
            Xeger xeger = new(LoginVORules.ValidChars);

            for (int i = 0; i < 100; i++)
            {
                string generatedLogin = xeger.Generate();
                LoginVO loginVO = new(generatedLogin);

                loginVOs.Add(loginVO);
            }

            return loginVOs;
        }

        public static ICollection<LoginVO> GetLoginVOs()
        {
            return LoginVOs;
        }

        public static LoginVO GetLoginVO()
        {
            Random random = new();
            int index = random.Next(0, 100);

            return LoginVOs.ElementAt(index);
        }
    }
}
