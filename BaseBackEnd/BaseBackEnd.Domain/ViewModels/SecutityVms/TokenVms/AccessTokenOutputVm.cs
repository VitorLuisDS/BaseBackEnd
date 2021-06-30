using BaseBackEnd.Domain.Constants.Security;
using System.Text.Json.Serialization;

namespace BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms
{
    public class AccessTokenOutputVm
    {
        [JsonPropertyName(AuthConstants.ACCESS_TOKEN_NAME)]
        public string AccessToken { get; set; }
    }
}
