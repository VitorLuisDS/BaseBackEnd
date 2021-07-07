namespace BaseBackEnd.Security.API.ViewModels.TokenVms
{
    public class TokensOutputVm : AccessTokenOutputVm
    {
        public string RefreshToken { get; set; }
    }
}
