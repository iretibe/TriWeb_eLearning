using eLearning.Application.Commands;
using eLearning.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public VideosController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        //[RequestSizeLimit(5_368_709_120)] // 5 GB
        [RequestSizeLimit(3_221_225_472)] // 3 GB in bytes
        [HttpPost("AddVideo")]
        public async Task<IActionResult> AddVideo([FromForm] AddVideoCommand command)
        {
            if (command.VideoFile == null || command.VideoFile.Length == 0)
                return BadRequest("No video file was uploaded.");

            // Step 1: Generate unique file name
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(command.VideoFile.FileName)}";

            // Step 2: Ensure uploads directory exists
            var videosPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(videosPath))
                Directory.CreateDirectory(videosPath);

            // Step 3: Full path for saving the file
            var fullPath = Path.Combine(videosPath, fileName);

            // Step 4: Stream to disk
            await using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 81920, useAsync: true))
            await using (var uploadStream = command.VideoFile.OpenReadStream()) // max size: 5 GB
            {
                await uploadStream.CopyToAsync(stream);
            }

            // Step 5: Set relative video URL
            command.VideoUrl = $"/uploads/{fileName}";

            // Step 6: Send to handler
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("GetCourseVideos/{courseId}")]
        public async Task<IActionResult> GetCourseVideos(Guid courseId)
            => Ok(await _mediator.Send(new GetVideosByCourseQuery(courseId)));
    }
}
