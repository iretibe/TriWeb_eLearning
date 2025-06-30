namespace eLearning.Domain.Dtos
{
    public class CourseReviewDto : CreateCourseReviewDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
