using System;

namespace BaseBackEnd.Infrastructure.Util.Exceptions
{
    public class RequestErrorException : Exception
    {
        public RequestErrorException(string message) : base(message)
        {

        }
    }
}
