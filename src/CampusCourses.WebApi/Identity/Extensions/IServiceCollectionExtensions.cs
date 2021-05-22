using System;
using System.Text;
using CampusCourses.WebApi.Identity.Data;
using CampusCourses.WebApi.Identity.Entities;
using CampusCourses.WebApi.Identity.Infrastructure;
using CampusCourses.WebApi.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace CampusCourses.WebApi.Identity.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddIdentityModule(
            this IServiceCollection services, 
            IConfiguration configuration, 
            IWebHostEnvironment environment)
        {
            services.AddDbContext<CampusCoursesIdentityContext>(options => {
                
                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                }

                options.UseSqlite(configuration.GetConnectionString("localhost"));
            });

            services.AddIdentityCore<CampusCourseUser>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.User.RequireUniqueEmail = true;
                }

                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddUserManager<UserManager<CampusCourseUser>>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<CampusCoursesIdentityContext>()
            .AddTokenProvider<JwtRefreshTokenProvider<CampusCourseUser>>(JwtRefreshTokenProvider<CampusCourseUser>.ProviderName);

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
                options.Name = JwtRefreshTokenProvider<CampusCourseUser>.ProviderName;
            });

            services.Configure<JwtTokenParameters>(configuration.GetSection(nameof(JwtTokenParameters)));

            services.AddScoped<JwtTokenService<CampusCourseUser>>();

        }
    }
}
