﻿namespace BaseBackEnd.Domain.Constants.Messages
{
    public static class SecurityMessages
    {
        public const string UNAUTHORIZED_MSG = "Not authorized";
        public const string EXPIRED_SESSION_MSG = "Session expired";
        public const string EXPIRED_TOKEN_MSG = "Token expired";
        public const string INVALID_TOKEN_MSG = "Invalid token";
        public const string BLACKLISTED_TOKEN_MSG = "Blacklisted token";
        public const string NO_REFRESH_TOKEN_MSG = "No refresh token provided";
        public const string TOKEN_CONCEIVED_MSG = "Token conceived";
        public const string USER_AUTHENTICATED_MSG = "User authenticated";
        public const string USER_DOES_NOT_EXIST_MSG = "User does not exist";
        public const string EXPIRED_TOKEN_AND_NO_REFRESH_TOKEN_MSG =
            EXPIRED_TOKEN_MSG +
            " and " +
            NO_REFRESH_TOKEN_MSG;
    }
}