using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.Price)
                   .HasColumnType("decimal(10,2)");

            builder.Property(c => c.ImageUrl)
                   .HasMaxLength(500);

            builder.Property(c => c.Rating);

            builder.Property(c => c.ReviewsCount);

            builder.Property(c => c.Duration)
                   .HasMaxLength(100);

            builder.Property(c => c.StudentsEnrolled);

            builder.Property(c => c.IsRetired)
                   .HasDefaultValue(false);

            builder.Property(c => c.CourseLanguage).HasMaxLength(100);

            builder.Property(c => c.CourseLevel).HasMaxLength(100);

            builder.Property(c => c.PublishedDate);

            builder.HasOne(c => c.Lecturer)
                   .WithMany(l => l.Courses)
                   .HasForeignKey(c => c.LecturerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
