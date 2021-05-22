using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using CampusCourses.WebApi.Common.Exceptions;
using CampusCourses.WebApi.Constants;
using CampusCourses.WebApi.Identity.Constants;
using CampusCourses.WebApi.Identity.Entities;
using CampusCourses.WebApi.Identity.Exceptions;
using CampusCourses.WebApi.Identity.Models;
using CampusCourses.WebApi.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CampusCourses.WebApi.Identity.Commands
{
    public class RegisterCommand : IRequest<AuthenticationViewModel>
    {

        public RegisterCommand(string username, string password)
        {
            Email = username;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationViewModel>
    {
        private readonly JwtTokenService<CampusCourseUser> tokenService;
        private readonly UserManager<CampusCourseUser> userManager;

        public RegisterCommandHandler(JwtTokenService<CampusCourseUser> tokenService, UserManager<CampusCourseUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }

        public async Task<AuthenticationViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new CampusCourseUser
            {
                Email = request.Email,
                UserName = request.Email,
            };

            try
            {
                var createUser = await userManager.CreateAsync(user, request.Password);

                if (!createUser.Succeeded)
                {
                    var errors = createUser.Errors.Select(error => error.Description).ToArray();
                    throw new AccountException(IdentityErrorCodes.CannotCreateAccount, 401, errors);
                }
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new CampusCoursesException(CampusCoursesErrorCodes.InternalServerError, 500);
            }

            try
            {
                var addToRole = await userManager.AddToRoleAsync(user, Roles.Administrator);

                if (!addToRole.Succeeded)
                {
                    throw new AccountException(IdentityErrorCodes.CannotCreateAccount, 500, new[] { "Unable to create user account." });
                }
            }
            catch(AccountException)
            {
                await userManager.DeleteAsync(user);
                throw;
            }
            catch
            {
                await userManager.DeleteAsync(user);
                throw new CampusCoursesException(CampusCoursesErrorCodes.InternalServerError, 500);
            }

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
                    throw new AccountException(IdentityErrorCodes.CannotCreateAccount, 500, new[] { "Unable to create user account." });
                }

                var tokens = await tokenService.GenerateToken(claims, user);

                return new AuthenticationViewModel()
                {
                    Authentication = new Token(tokens.RefreshToken, tokens.Token),
                    Id = user.Id,
                    Email = user.Email,
                    // TODO: placeholder needs to updated to use user custom avatar
                    Avatar = "https://via.placeholder.com/150",
                };
            }
            catch
            {
                await userManager.DeleteAsync(user);
                throw new CampusCoursesException(CampusCoursesErrorCodes.InternalServerError, 500);
            }

        }
    }
}
