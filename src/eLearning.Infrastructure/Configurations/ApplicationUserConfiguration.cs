using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.Courses)
                   .WithOne(c => c.Lecturer)
                   .HasForeignKey(c => c.LecturerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Enrollments)
                   .WithOne(e => e.Learner)
                   .HasForeignKey(e => e.LearnerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
