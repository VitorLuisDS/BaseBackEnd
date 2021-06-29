using BaseBackEnd.Domain.Constants;
using System.Text.Json.Serialization;

namespace BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms
{
    public class TokensOutputVm : AccessTokenOutputVm
    {
        [JsonPropertyName(SecurityConstants.REFRESH_TOKEN_NAME)]
        public string RefreshToken { get; set; }
    }
}
