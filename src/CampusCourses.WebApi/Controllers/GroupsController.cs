using CampusCourses.WebApi.Identity.Constants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCourses.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class GroupsController : ControllerBase
    {

        [Authorize(Roles = "Administrator")]
        [HttpPost(Name = nameof(CreateGroup))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateGroup()
        {
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPatch(Name = nameof(UpdateGroup))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateGroup()
        {
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete(Name = nameof(DeleteGroup))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteGroup()
        {
            return Ok();
        }

        [HttpGet(Name = nameof(GetGroup))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetGroup()
        {
            return Ok();
        }

        [HttpGet(Name = nameof(GetGroups))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetGroups()
        {
            return Ok();
        }
    }
}