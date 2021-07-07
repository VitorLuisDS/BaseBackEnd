namespace BaseBackEnd.Security.Domain.Enums
{
    public enum InvalidTokenType
    {
        Expired,
        NotProvided,
        Blacklisted,
        Other
    }
}
