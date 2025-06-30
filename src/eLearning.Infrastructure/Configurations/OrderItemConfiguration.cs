using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Price)
                  .HasColumnType("decimal(18,2)");

            builder.HasOne(oi => oi.Course)
                  .WithMany()
                  .HasForeignKey(oi => oi.CourseId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
