using BaseBackEnd.API.Constants;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BaseBackEnd.API.Models.Attributes
{
    public class ProducesBaseAttribute : ProducesAttribute
    {
        /// <summary>
        /// If no content type is provided, the default value will be "application/json".
        /// </summary>
        public ProducesBaseAttribute() : base(ContentTypeConstants.JSON)
        {

        }

        public ProducesBaseAttribute(Type type) : base(ContentTypeConstants.JSON)
        {
            Type = type;
        }

        public ProducesBaseAttribute(string contentType, params string[] additionalContentTypes) : base(contentType, additionalContentTypes)
        {
        }
    }
}
