namespace BaseBackEnd.Domain.Constants
{
    public static class SecurityConstants
    {
        public const string POLICY_DEFAULT_NAME = "PolicyDefault";
        public const string ACCESS_TOKEN_NAME = "access_token";
        public const string REFRESH_TOKEN_NAME = "refresh_token";
        public const string NEW_TOKEN_NAME = "new_token";

        public const string UNAUTHORIZED_MSG = "Not authorized";
        public const string EXPIRED_SESSION_MSG = "Session expired";
        public const string EXPIRED_TOKEN_MSG = "Token expired";
        public const string INVALID_TOKEN_MSG = "Invalid token";
    }
}
