using MediatR;
using Microsoft.AspNetCore.Http;

namespace eLearning.Application.Commands
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string LecturerId { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Duration { get; set; } = default!;
        public IFormFile? ImageFile { get; set; }
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
    }
}
