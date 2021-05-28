using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using CampusCourses.WebApi.Common.Constants;
using CampusCourses.WebApi.Common.ViewModels;
using CampusCourses.WebApi.Identity.Constants;
using CampusCourses.WebApi.Identity.Entities;
using CampusCourses.WebApi.Identity.Models;
using CampusCourses.WebApi.Identity.Services;

using MediatR;

using Microsoft.AspNetCore.Identity;

using OneOf;

namespace CampusCourses.WebApi.Identity.Commands
{
    public class RegisterCommand : IRequest<OneOf<AuthenticationViewModel, ErrorViewModel>>
    {

        public RegisterCommand(string username, string password)
        {
            Email = username;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthenticationViewModel, ErrorViewModel>>
    {
        private readonly JwtTokenService<CampusCoursesUser> tokenService;
        private readonly UserManager<CampusCoursesUser> userManager;

        public RegisterCommandHandler(JwtTokenService<CampusCoursesUser> tokenService, UserManager<CampusCoursesUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        public async Task<OneOf<AuthenticationViewModel, ErrorViewModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new CampusCoursesUser
            {
                Email = request.Email,
                UserName = request.Email,
            };

            /* create user */
            var createUser = await userManager.CreateAsync(user, request.Password);

            if (!createUser.Succeeded)
            {
                var errors = createUser.Errors.Select(error => error.Description).ToArray();
                return new ErrorViewModel(IdentityErrorCodes.CannotCreateAccount, 401, errors);
            }


            /* assign role to user */
            try
            {
                var addToRole = await userManager.AddToRoleAsync(user, Roles.Administrator);

                if (!addToRole.Succeeded)
                {
                    return new ErrorViewModel(IdentityErrorCodes.CannotCreateAccount, 500, new[] { "Unable to create user account." });
                }
            }
            catch
            {
                await userManager.DeleteAsync(user);
                return new ErrorViewModel(CampusCoursesErrorCodes.InternalServerError, 500);
            }

            /* create user claims */
            try
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, Roles.Administrator)
                };

                var addClaims = await userManager.AddClaimsAsync(user, claims);

                if (!addClaims.Succeeded)
                {
                    return new ErrorViewModel(IdentityErrorCodes.CannotCreateAccount, 500, new[] { "Unable to create user account." });
                }

                /* generate JWt token */
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
            catch
            {
                await userManager.DeleteAsync(user);
                return new ErrorViewModel(CampusCoursesErrorCodes.InternalServerError, 500);
            }

        }
    }
}
