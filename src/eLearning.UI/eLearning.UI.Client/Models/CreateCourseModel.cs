using Microsoft.AspNetCore.Components.Forms;

namespace eLearning.UI.Client.Models
{
    public class CreateCourseModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = default!;
        public string Duration { get; set; } = default!;
        public IBrowserFile? ImageFile { get; set; } = default!;
        public string LecturerName { get; set; } = default!;
    }
}
