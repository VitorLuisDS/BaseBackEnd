using System;

namespace BaseBackEnd.Infrastructure.Util.Exceptions
{
    public class ConstraintViolationException : Exception
    {
        public ConstraintViolationException(string message) : base(message)
        {

        }
    }
}
