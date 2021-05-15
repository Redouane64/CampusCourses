using System.Threading.Tasks;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CompusCourse.WebApi.Identity.Extensions
{
    public sealed class JwtRefreshTokenProviderOptions : DataProtectionTokenProviderOptions
    {
    }

    public sealed class JwtRefreshTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public static readonly string ProviderName = "JwtRefreshTokenProvider";
        public static readonly string Purpose = "RefershJwtAccessToken";

        public JwtRefreshTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<JwtRefreshTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger
        ) : base(dataProtectionProvider, options, logger)
        {
        }

        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }

    }
}
