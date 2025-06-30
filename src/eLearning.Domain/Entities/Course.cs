namespace eLearning.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public bool IsRetired { get; set; } = false;
        public DateTime? RetireDate { get; set; }
        public string ImageUrl { get; set; } = default!;
        public double? Rating { get; set; }
        public int? ReviewsCount { get; set; }
        public string Duration { get; set; } = default!;
        public int? StudentsEnrolled { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public string CourseLanguage { get; set; } = default!;
        public string CourseLevel { get; set; } = default!;

        public string LecturerId { get; set; } = default!;
        public ApplicationUser Lecturer { get; set; } = default!;

        public ICollection<VideoContent> Videos { get; set; } = default!;
        public ICollection<Enrollment> Enrollments { get; set; } = default!;

        public ICollection<CourseReview> Reviews { get; set; } = new List<CourseReview>();
    }
}
