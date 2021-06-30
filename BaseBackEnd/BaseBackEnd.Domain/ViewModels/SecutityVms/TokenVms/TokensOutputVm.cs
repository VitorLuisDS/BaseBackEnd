using BaseBackEnd.Domain.Constants.Security;
using System.Text.Json.Serialization;

namespace BaseBackEnd.Domain.ViewModels.SecutityVms.TokenVms
{
    public class TokensOutputVm : AccessTokenOutputVm
    {
        [JsonPropertyName(AuthConstants.REFRESH_TOKEN_NAME)]
        public string RefreshToken { get; set; }
    }
}
