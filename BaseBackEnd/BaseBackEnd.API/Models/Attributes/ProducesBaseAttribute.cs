using Microsoft.AspNetCore.Mvc;
using System;

namespace BaseBackEnd.API.Models.Attributes
{
    public class ProducesBaseAttribute : ProducesAttribute
    {
        public const string JSON = "application/json";

        /// <summary>
        /// If no content type is provided, the default value will be "application/json".
        /// </summary>
        public ProducesBaseAttribute() : base(JSON)
        {

        }

        public ProducesBaseAttribute(Type type) : base(JSON)
        {
            Type = type;
        }

        public ProducesBaseAttribute(string contentType, params string[] additionalContentTypes) : base(contentType, additionalContentTypes)
        {
        }
    }
}
