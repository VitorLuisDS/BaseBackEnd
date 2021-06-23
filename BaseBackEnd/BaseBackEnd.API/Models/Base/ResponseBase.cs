using System.Net;

namespace BaseBackEnd.API.Models.Base
{
    public class ResponseBase<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }

        public ResponseBase()
        {

        }

        public ResponseBase(T content, HttpStatusCode statusCode = HttpStatusCode.OK, string message = default)
        {
            this.Content = content;
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public ResponseBase(HttpStatusCode statusCode, string message = default)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }

    public class ResponseBase
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ResponseBase()
        {

        }

        public ResponseBase(HttpStatusCode statusCode = HttpStatusCode.OK, string message = default)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}
