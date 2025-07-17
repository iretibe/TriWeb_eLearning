namespace eLearning.UI.Client.Models
{
    public class VideoContentModel
    {
        public string Title { get; set; } = default!;
        public string? VideoUrl { get; set; }
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = default!;
    }
}
