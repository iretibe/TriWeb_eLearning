using eLearning.Application.Commands;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public CoursesController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses() => Ok(await _mediator.Send(new GetAllCoursesQuery()));

        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var result = await _mediator.Send(new GetCoursesByIdQuery(id));

            return Ok(result);
        }

        [HttpGet("GetRating/{courseId}")]
        public async Task<IActionResult> GetRating(Guid courseId)
        {
            var rating = await _mediator.Send(new CalculateCourseRatingQuery(courseId));
            return Ok(rating);
        }

        [HttpGet("GetReviewCount/{courseId}")]
        public async Task<IActionResult> GetReviewCount(Guid courseId)
        {
            var count = await _mediator.Send(new GetReviewCountQuery(courseId));
            return Ok(count);
        }

        [HttpGet("GetEnrollmentCount/{courseId}")]
        public async Task<IActionResult> GetEnrollmentCount(Guid courseId)
        {
            var count = await _mediator.Send(new GetStudentEnrollmentCountQuery(courseId));
            return Ok(count);
        }

        [HttpGet("GetUserCourses/{userId}")]
        public async Task<IActionResult> GetUserCourses(string userId)
        {
            var result = await _mediator.Send(new GetUserCoursesQuery(userId));
            return Ok(result);
        }

        [HttpPost("RecalculateStats/{courseId}")]
        public async Task<IActionResult> RecalculateStats(Guid courseId)
        {
            await _mediator.Send(new RecalculateCourseStatisticsCommand(courseId));
            return NoContent();
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseDto request)
        {
            if (request.ImageFile == null || request.ImageFile.Length == 0)
                return BadRequest("Image file is required.");

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            //Directory.CreateDirectory(uploadsFolder);

            string fileName = Guid.NewGuid() + Path.GetExtension(request.ImageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            var command = new CreateCourseCommand
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                LecturerId = request.LecturerId,
                Duration = request.Duration,
                ImageUrl = $"/uploads/{fileName}",
                ImageFile = request.ImageFile
            };

            var courseId = await _mediator.Send(command);

            return Ok(courseId);
        }

        [HttpPut("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseDto dto)
        {
            await _mediator.Send(new UpdateCourseCommand(id, dto));

            return NoContent();
        }

        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            await _mediator.Send(new DeleteCourseCommand(id));
            return NoContent();
        }
    }
}
