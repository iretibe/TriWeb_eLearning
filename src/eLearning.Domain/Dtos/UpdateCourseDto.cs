using Microsoft.AspNetCore.Http;

namespace eLearning.Domain.Dtos
{
    public class UpdateCourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = default!;
        public string Duration { get; set; } = default!;
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
        public string LecturerId { get; set; } = default!;
        public IFormFile? ImageFile { get; set; }
    }
}
