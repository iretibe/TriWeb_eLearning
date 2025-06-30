using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator) => _mediator = mediator;

        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification([FromBody] SendCourseRetirementNoticeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("GetUserNotifications/{userId}")]
        public async Task<IActionResult> GetUserNotifications(string userId) => Ok(await _mediator.Send(new GetUserNotificationsQuery(userId)));
    }
}
