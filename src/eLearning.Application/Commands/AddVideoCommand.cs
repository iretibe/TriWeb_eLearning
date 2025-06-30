using MediatR;
using Microsoft.AspNetCore.Http;

namespace eLearning.Application.Commands
{
    //public record AddVideoCommand(string Title, string VideoUrl, Guid CourseId) : IRequest;
    public class AddVideoCommand : IRequest
    {
        public string Title { get; set; } = default!;
        public IFormFile VideoFile { get; set; } = default!;
        public Guid CourseId { get; set; }

        // This will be set in the controller
        public string VideoUrl { get; set; } = default!;
    }
}
