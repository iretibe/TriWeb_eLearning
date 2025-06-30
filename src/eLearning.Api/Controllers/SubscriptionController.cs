using eLearning.Application.Commands;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Subscribe")]
        [Authorize]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Subscribed successfully.");
        }

        [HttpGet("IsSubscribed/{userId}")]
        [Authorize]
        public async Task<ActionResult<bool>> IsSubscribed(string userId)
        {
            var result = await _mediator.Send(new IsSubscribedQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("GetSubscription/{userId}")]
        [Authorize]
        public async Task<ActionResult<SubscriptionDto?>> GetSubscription(string userId)
        {
            var result = await _mediator.Send(new GetSubscriptionQuery { UserId = userId });
            return Ok(result);
        }
    }
}
