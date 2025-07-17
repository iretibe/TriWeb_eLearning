using Microsoft.AspNetCore.Components.Forms;

namespace eLearning.WebApp.Client.Models
{
    public class CreateCourseModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Duration { get; set; } = default!;
        public IBrowserFile? ImageFile { get; set; } = default!;
        public string LecturerName { get; set; } = default!;
        public int StudentsEnrolled { get; set; } = 0;
        public int ReviewsCount { get; set; } = 0;
        public double Rating { get; set; } = 0.0;
        public DateTime PublishedDate { get; set; }
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
        public List<string> VideoUrls { get; set; } = new();
    }
}
