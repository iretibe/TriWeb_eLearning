using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Enroll(string userId, Guid courseId)
        {
            await _mediator.Send(new AddEnrollLearnerCommand(userId, courseId));
            return NoContent();
        }

        [HttpGet("GetEnrollments/{userId}")]
        public async Task<IActionResult> GetEnrollments(string userId) => Ok(await _mediator.Send(new GetUserEnrollmentsQuery(userId)));

        [HttpGet("IsEnrolled/{userId}/{courseId}")]
        public async Task<IActionResult> IsEnrolled(string userId, Guid courseId)
            => Ok(await _mediator.Send(new IsUserEnrolledQuery(userId, courseId)));
    }
}
