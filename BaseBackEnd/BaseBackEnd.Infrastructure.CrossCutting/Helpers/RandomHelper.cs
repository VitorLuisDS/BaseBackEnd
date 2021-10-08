using System;
using System.Linq;

namespace BaseBackEnd.Security.Infrastructure.CrossCutting.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random random = new Random();
        public static string RandomString(int length)
        {
            string chars = CharHelper.GetAllPrintableChars();
            string generatedString =
                new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

            return generatedString;
        }

        public static int RandomIntInRange(int min, int max)
        {
            int number = random.Next(min, max);

            return number;
        }
    }
}
