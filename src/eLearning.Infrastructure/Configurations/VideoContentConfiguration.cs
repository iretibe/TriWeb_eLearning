using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class VideoContentConfiguration : IEntityTypeConfiguration<VideoContent>
    {
        public void Configure(EntityTypeBuilder<VideoContent> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Title).HasMaxLength(200);
            builder.HasOne(v => v.Course)
                   .WithMany(c => c.Videos)
                   .HasForeignKey(v => v.CourseId);
        }
    }
}
