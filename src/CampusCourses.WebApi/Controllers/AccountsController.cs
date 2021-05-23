using System.Threading.Tasks;

using CampusCourses.WebApi.Common.ViewModels;
using CampusCourses.WebApi.Identity.Commands;
using CampusCourses.WebApi.Identity.Models;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusCourses.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("signin", Name = nameof(SignIn))]
        [ProducesResponseType(typeof(AuthenticationViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody]Login login)
        {
            var result = await mediator.Send(new LoginCommand(login.Email, login.Password));

            return result.Match<IActionResult>(
                authentication => Ok(authentication),
                error => BadRequest(error)
            );
        }

        [HttpPost("signup", Name = nameof(SignUp))]
        [ProducesResponseType(typeof(AuthenticationViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody]Register register)
        {
            var result = await mediator.Send(new RegisterCommand(register.Email, register.Password));
            return result.Match<IActionResult>(
                authentication => Ok(authentication),
                error => BadRequest(error)
            );
        }
    }
}
