using eLearning.Application.Commands;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] CreateCourseReviewDto dto)
        {
            await _mediator.Send(new CreateCourseReviewCommand(dto));
            return Ok();
        }

        [HttpGet("GetReviewsByCourse/{courseId}")]
        public async Task<IActionResult> GetReviewsByCourse(Guid courseId)
        {
            var reviews = await _mediator.Send(new GetCourseReviewsQuery(courseId));
            return Ok(reviews);
        }

        [HttpGet("GetReviewById/{reviewId}")]
        public async Task<IActionResult> GetReviewById(Guid reviewId)
        {
            var review = await _mediator.Send(new GetCourseReviewByIdQuery(reviewId));
            return review is null ? NotFound() : Ok(review);
        }

        [HttpDelete("DeleteReview/{reviewId}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            await _mediator.Send(new DeleteCourseReviewCommand(reviewId));
            return NoContent();
        }

        [HttpGet("GetAverageRating/{courseId}")]
        public async Task<IActionResult> GetAverageRating(Guid courseId)
        {
            var rating = await _mediator.Send(new GetCourseAverageRatingQuery(courseId));
            return Ok(rating);
        }

        [HttpGet("GetReviewCount/{courseId}")]
        public async Task<IActionResult> GetReviewCount(Guid courseId)
        {
            var count = await _mediator.Send(new GetCourseReviewCountQuery(courseId));
            return Ok(count);
        }
    }
}
