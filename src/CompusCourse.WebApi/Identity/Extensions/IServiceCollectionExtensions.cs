using CompusCourse.WebApi.Identity.Infrastructure;
using CompusCourse.WebApi.Identity.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Identity.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddIdentity<TUser>(this IServiceCollection services, IConfiguration configuration)
            where TUser : class
        {
            services.AddIdentityCore<TUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddUserManager<UserManager<TUser>>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddTokenProvider<JwtRefreshTokenProvider<TUser>>(JwtRefreshTokenProvider<TUser>.ProviderName);

            // Configure JWT authentication schema
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // Get token parameters from configuration.
                var jwtOptions = configuration.GetSection(nameof(JwtTokenParameters)).Get<JwtTokenParameters>();
                options.RequireHttpsMetadata = false; // TODO: enable on production environment
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                    ValidAudience = jwtOptions.Audience,
                    ValidIssuer = jwtOptions.Issuer,
                };
            });

            // Configure authorization
            services.AddAuthorization();

            // Configure JWT refresh token provider
            services.Configure<JwtRefreshTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(configuration.GetValue<double>("JwtTokenParameters:LifeTime") * 2);
                options.Name = JwtRefreshTokenProvider<TUser>.ProviderName;
            });

            services.Configure<JwtTokenParameters>(configuration.GetSection(nameof(JwtTokenParameters)));

            services.AddScoped<JwtTokenService<TUser>>();

        }
    }
}
