using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class SubscriptionOrderConfiguration : IEntityTypeConfiguration<SubscriptionOrder>
    {
        public void Configure(EntityTypeBuilder<SubscriptionOrder> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.SubscriptionType).IsRequired();
            builder.Property(o => o.Status).HasMaxLength(20);
            builder.HasOne(o => o.User)
                   .WithMany()
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Course)
                   .WithMany()
                   .HasForeignKey(o => o.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
