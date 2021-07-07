using BaseBackEnd.Security.API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BaseBackEnd.Security.API.Models.Attributes
{
    public class ProducesResponseTypeBaseAttribute : ProducesResponseTypeAttribute
    {
        public ProducesResponseTypeBaseAttribute(Type type, HttpStatusCode statusCode) : base(type, (int)statusCode)
        {

        }

        public ProducesResponseTypeBaseAttribute(HttpStatusCode statusCode) : base(typeof(ResponseBase), (int)statusCode)
        {

        }
    }
}
