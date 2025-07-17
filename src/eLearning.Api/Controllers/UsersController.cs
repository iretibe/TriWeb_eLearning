using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers() => Ok(await _mediator.Send(new GetAllUsersQuery()));

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(string userId) => Ok(await _mediator.Send(new GetUserByIdQuery(userId)));

        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers() => Ok(await _mediator.Send(new GetAllTeachersQuery()));

        [HttpGet("GetTeacherById/{userId}")]
        public async Task<IActionResult> GetTeacherById(string userId) => Ok(await _mediator.Send(new GetTeacherByIdQuery(userId)));

        [HttpGet("GetUserRoles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId) => Ok(await _mediator.Send(new GetUserRolesQuery(userId)));

        [HttpGet("GetUserIdByEmail")]
        public async Task<IActionResult> GetUserIdByEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required.");

            var userId = await _mediator.Send(new GetUserIdByEmailQuery(email));

            if (string.IsNullOrEmpty(userId))
                return NotFound($"User with email '{email}' not found.");

            return Ok(new { userId });
        }

        [HttpPost("AssignRole/{userId}")]
        public async Task<IActionResult> AssignRole(string userId, [FromBody] string role)
        {
            await _mediator.Send(new AssignUserRoleCommand(userId, role));
            return NoContent();
        }
    }
}
