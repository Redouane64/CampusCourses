using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CampusCourses.WebApi.Identity.Constants;
using CampusCourses.WebApi.Identity.Entities;
using CampusCourses.WebApi.Identity.Exceptions;
using CampusCourses.WebApi.Identity.Models;
using CampusCourses.WebApi.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CampusCourses.WebApi.Identity.Commands
{
    public class LoginCommand : IRequest<AuthenticationViewModel>
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }

        public string Password { get; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationViewModel>
    {

        private readonly JwtTokenService<CampusCourseUser> tokenService;
        private readonly UserManager<CampusCourseUser> userManager;

        public LoginCommandHandler(JwtTokenService<CampusCourseUser> tokenService, UserManager<CampusCourseUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        public async Task<AuthenticationViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.FindByEmailAsync(request.Username);

            if (user is null)
            {
                throw new AccountException(IdentityErrorCodes.InvalidCredentials, 401, null);
            }

            var isValidPassword = await this.userManager.CheckPasswordAsync(user, request.Password);

            if (!isValidPassword)
            {
                throw new AccountException(IdentityErrorCodes.InvalidCredentials, 401, null);
            }

            var claims = await userManager.GetClaimsAsync(user);

            var tokens = await tokenService.GenerateToken(claims, user);

            return new AuthenticationViewModel()
            {
                Authentication = new Token(tokens.RefreshToken, tokens.Token),
                Id = user.Id,
                Email = user.Email,
                // TODO: placeholder needs to updated to use user custom avatar
                Avatar = "https://via.placeholder.com/150",
                Role = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).FirstOrDefault()
            };
        }
    }
}
