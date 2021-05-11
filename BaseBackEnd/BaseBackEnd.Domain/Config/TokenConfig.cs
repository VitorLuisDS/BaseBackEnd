namespace BaseBackEnd.Domain.Config
{
    public class TokenConfig
    {
        public string Secret { get; set; }
        public double AccessTokenDurationInSeconds { get; set; }
        public double RefreshTokenDurationInMinutes { get; set; }
        public string[] ValidIssuers { get; set; }
    }
}
