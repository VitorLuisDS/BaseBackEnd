using System;

namespace BaseBackEnd.Infrastructure.CrossCutting.Exceptions
{
    public class ConstraintViolationException : Exception
    {
        public ConstraintViolationException(string message) : base(message)
        {

        }
    }
}
