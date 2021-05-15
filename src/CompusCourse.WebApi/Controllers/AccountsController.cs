using CompusCourse.WebApi.Identity.Commands;
using CompusCourse.WebApi.Identity.Models;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompusCourse.WebApi.Controllers
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
        public async Task<IActionResult> SignIn(
            [FromBody, Required]string username, 
            [FromBody, Required] string password)
        {
            return Ok(await mediator.Send(new LoginCommand(username, password)));
        }

        [HttpPost("signup", Name = nameof(SignUp))]
        public async Task<IActionResult> SignUp(Register body)
        {
            return Ok(await mediator.Send(new RegisterCommand(body.Username, body.Password)));
        }
    }
}
