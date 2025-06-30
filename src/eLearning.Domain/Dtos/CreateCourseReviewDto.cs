namespace eLearning.Domain.Dtos
{
    public class CreateCourseReviewDto
    {
        public Guid CourseId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
