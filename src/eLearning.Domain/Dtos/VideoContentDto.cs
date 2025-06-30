namespace eLearning.Domain.Dtos
{
    public class VideoContentDto
    {
        public string Title { get; set; } = default!;
        public string VideoUrl { get; set; } = default!;
        public Guid CourseId { get; set; }
    }
}
