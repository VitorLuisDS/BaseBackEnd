using System;

namespace BaseBackEnd.Infrastructure.Util.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
