using BaseBackEnd.Security.Domain.Rules;
using BaseBackEnd.Security.Domain.ValueObjects;
using Fare;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Tests.Domain.Fakes.ValueObjects
{
    public static class FakeNameVOData
    {
        private static readonly ICollection<NameVO> NameVOs;

        static FakeNameVOData()
        {
            NameVOs = CreateNameVOs();
        }

        private static ICollection<NameVO> CreateNameVOs()
        {
            ICollection<NameVO> nameVOs = new List<NameVO>();
            Xeger xeger = new(NameVORules.ValidChars);

            for (int i = 0; i < 100; i++)
            {
                string generatedLogin = xeger.Generate();
                NameVO nameVO = new(generatedLogin);

                nameVOs.Add(nameVO);
            }

            return nameVOs;
        }

        public static ICollection<NameVO> GetNameVOs()
        {
            return NameVOs;
        }

        public static NameVO GetNameVO()
        {
            Random random = new();
            int index = random.Next(0, 100);

            return NameVOs.ElementAt(index);
        }
    }
}
