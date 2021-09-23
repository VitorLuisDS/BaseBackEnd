﻿using System.Text.RegularExpressions;

namespace BaseBackEnd.Security.API.ViewModels.Validators.Base
{
    public static class RegexPatterns
    {
        public static Regex ValidLoginPattern { get; } = new Regex("^[aA-zZ0-9_-]+$");
    }
}