using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.RegexPatterns
{
    public static class LoginVORules
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;
        public static string ValidChars { get; } = $@"^[a-zA-Z0-9._]{{{MIN_LENGTH},{MAX_LENGTH}}}$";
    }
}
