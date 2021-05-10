using System.Text.Json.Serialization;

namespace BaseBackEnd.Domain.ViewModels.SecutityVms
{
    public class AccessTokenOutputVm
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
