using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CampusCourses.Domain.Identity;
using CampusCourses.WebApi.Identity.Constants;
using CampusCourses.WebApi.Identity.Exceptions;
using CampusCourses.WebApi.Identity.Extensions;
using CampusCourses.WebApi.Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CampusCourses.WebApi.Identity.Services
{

    public sealed class JwtTokenService<TUser> where TUser: class, IUser
    {

        private readonly JwtRefreshTokenProvider<TUser> _jwtRefreshTokenProvider;
        private readonly UserManager<TUser> _userManager;
        private readonly JwtTokenParameters _jwtTokenOptions;

        public JwtTokenService(
            IOptions<JwtTokenParameters> jwtTokenOptions,
            JwtRefreshTokenProvider<TUser> jwtRefreshTokenProvider,
            UserManager<TUser> userManager
            )
        {
            _jwtRefreshTokenProvider = jwtRefreshTokenProvider;
            _userManager = userManager;
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        public async Task<(string Token, string RefreshToken)> GenerateToken(
            IEnumerable<Claim> claims,
            TUser user)
        {
            if (claims == null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtTokenOptions.Secret));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: this._jwtTokenOptions.Issuer,
                audience: this._jwtTokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(this._jwtTokenOptions.LifeTime),
                signingCredentials: signingCredentials
            );

            var refreshToken = await this._jwtRefreshTokenProvider.GenerateAsync(JwtRefreshTokenProvider<TUser>.Purpose, _userManager, user);

            var stringifiedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return (Token: stringifiedToken, RefreshToken: refreshToken);
        }

        public async Task<(string Token, string RefreshToken)> RefreshToken(string refreshToken, TUser user, IEnumerable<Claim> claims)
        {
            var isValid = await this._jwtRefreshTokenProvider.ValidateAsync(JwtRefreshTokenProvider<TUser>.Purpose, refreshToken, _userManager, user);

            if (!isValid)
            {
                throw new AccountException(IdentityErrorCodes.InvalidRefreshToken, 401, null);
            }

            return await this.GenerateToken(claims, user);
        }

    }

}
