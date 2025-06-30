using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator) => _mediator = mediator;

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("GetSubscription/{userId}")]
        public async Task<IActionResult> GetSubscription(string userId)
            => Ok(await _mediator.Send(new GetUserSubscriptionQuery(userId)));

        [HttpGet("IsSubscribed/{userId}")]
        public async Task<IActionResult> IsSubscribed(string userId)
            => Ok(await _mediator.Send(new IsUserSubscribedQuery(userId)));
    }
}
