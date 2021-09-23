using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Rules
{
    public static class NameVORules
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 50;
        public static string ValidChars { get; } = @"^[A-Za-zÀ-ÖØ-öø-ÿ']{4,}(?: [A-Za-zÀ-ÖØ-öø-ÿ']+){0,8}$";
    }
}
