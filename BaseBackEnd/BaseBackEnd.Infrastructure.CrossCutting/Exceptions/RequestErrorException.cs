namespace BaseBackEnd.Security.Infrastructure.CrossCutting.Exceptions
{
    public class RequestErrorException : Exception
    {
        public RequestErrorException(string message) : base(message)
        {

        }
    }
}
