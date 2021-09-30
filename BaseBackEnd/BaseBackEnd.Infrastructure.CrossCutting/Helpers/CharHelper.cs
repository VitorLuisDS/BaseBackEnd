using System;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Infrastructure.CrossCutting.Helpers
{
    public static class CharHelper
    {
        public static string GetAllPrintableChars()
        {
            List<char> printableChars = new List<char>();
            for (int i = char.MinValue; i <= char.MaxValue; i++)
            {
                char c = Convert.ToChar(i);
                if (!char.IsControl(c))
                {
                    printableChars.Add(c);
                }
            }

            return string.Join(null, printableChars.ToArray());
        }
    }
}
