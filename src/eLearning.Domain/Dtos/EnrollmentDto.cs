namespace eLearning.Domain.Dtos
{
    public class EnrollmentDto
    {
        public Guid Id { get; set; }
        public string LearnerId { get; set; } = default!;
        public Guid CourseId { get; set; }
        public DateTime EnrolledOn { get; set; }
    }
}
