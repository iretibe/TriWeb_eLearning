namespace eLearning.Domain.Entities
{
    public class VideoContent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string VideoUrl { get; set; } = default!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
