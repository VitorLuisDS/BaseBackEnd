using BaseBackEnd.Domain.Constants;
using System.Text.Json.Serialization;

namespace BaseBackEnd.Domain.ViewModels.SecutityVms
{
    public class AccessTokenOutputVm
    {
        [JsonPropertyName(SecurityConstants.ACCESS_TOKEN_NAME)]
        public string AccessToken { get; set; }
    }
}
