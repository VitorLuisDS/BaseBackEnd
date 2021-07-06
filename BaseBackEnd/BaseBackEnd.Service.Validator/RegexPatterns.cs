using System.Text.RegularExpressions;

namespace BaseBackEnd.Service.Validator
{
    public static class RegexPatterns
    {
        public static Regex ValidLoginPattern { get; } = new Regex("^[aA-zZ0-9_-]+$");
    }
}
