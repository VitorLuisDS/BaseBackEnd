using System;

namespace BaseBackEnd.Infrastructure.CrossCutting.Exceptions
{
    public class RequestErrorException : Exception
    {
        public RequestErrorException(string message) : base(message)
        {

        }
    }
}
