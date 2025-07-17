using Microsoft.AspNetCore.Http;

namespace eLearning.Domain.Dtos
{
    public class CreateCourseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string LecturerId { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string Duration { get; set; } = default!;
        public IFormFile? ImageFile { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
    }
}
