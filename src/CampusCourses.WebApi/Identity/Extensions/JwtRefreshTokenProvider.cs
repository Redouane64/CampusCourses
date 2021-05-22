using System.Threading.Tasks;
using CampusCourses.Domain.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CampusCourses.WebApi.Identity.Extensions
{
    public sealed class JwtRefreshTokenProviderOptions : DataProtectionTokenProviderOptions
    {
    }

    public sealed class JwtRefreshTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class, IUser
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
