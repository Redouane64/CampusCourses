using System.Threading.Tasks;
using CampusCourses.WebApi.Identity.Commands;
using CampusCourses.WebApi.Identity.Exceptions;
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
        public async Task<IActionResult> SignIn([FromBody]Login login)
        {
            try
            {
                var result = await mediator.Send(new LoginCommand(login.Email, login.Password));
                return Ok(result);
            }
            catch (AccountException aex) when (aex.Status == 401)
            {
                return BadRequest(new { error = aex.Code, message = aex.Errors });
            }
        }

        [HttpPost("signup", Name = nameof(SignUp))]
        [ProducesResponseType(typeof(AuthenticationViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromBody]Register register)
        {
            try
            {
                var result = await mediator.Send(new RegisterCommand(register.Email, register.Password));
                return Ok(result);
            }
            catch (AccountException aex) when (aex.Status == 401)
            {
                return BadRequest(new { error = aex.Code });
            }
        }
    }
}
