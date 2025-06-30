using Microsoft.AspNetCore.Identity;

namespace eLearning.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
