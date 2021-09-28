using System;

namespace BaseBackEnd.Security.Infrastructure.CrossCutting.Exceptions
{
    public class ConstraintViolationException : Exception
    {
        public ConstraintViolationException(string message) : base(message)
        {

        }
    }
}
