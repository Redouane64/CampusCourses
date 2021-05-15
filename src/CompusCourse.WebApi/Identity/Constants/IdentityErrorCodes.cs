using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Identity.Constants
{
    public static class IdentityErrorCodes
    {
        public static readonly string InvalidCredentials = "incorrect_credentials";
        public static readonly string InvalidRefreshToken = "invalid_refresh_token";
    }
}
