using Blazorise;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLearning.UI.Client.Models
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public bool IsRetired { get; set; }
        public DateTime? RetireDate { get; set; }
        public string LecturerId { get; set; } = default!;
        public string LecturerName { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double? Rating { get; set; }
        public int? ReviewsCount { get; set; }
        public string Duration { get; set; } = default!;
        public int? StudentsEnrolled { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;
        //public IBrowserFile? ImageFile { get; set; }
        public List<string> VideoUrls { get; set; } = new();
    }
}
