using Blazorise;
using Microsoft.AspNetCore.Components.Forms;

namespace eLearning.UI.Client.Models
{
    public class CreateCourseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string LecturerId { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string Duration { get; set; } = default!;
        //public IFormFile? ImageFile { get; set; }
        public IBrowserFile? ImageFile { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Today;
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
    }
}
