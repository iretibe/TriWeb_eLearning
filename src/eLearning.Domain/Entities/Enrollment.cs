namespace eLearning.Domain.Entities
{
    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LearnerId { get; set; } = default!;
        public ApplicationUser Learner { get; set; } = default!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;
    }
}
