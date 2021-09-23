﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Rules
{
    public static class CodeVORules
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 50;
        public const string VALID_CHARS = @"^[a-zA-Z\-]{0,}$";
    }
}