using System;

namespace CompusCourse.WebApi.Identity.Models
{
    public class Token
    {
        public Token(string refreshToken, string accessToken)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }

        public string AccessToken { get; }

        public string RefreshToken { get; }

    }
}
