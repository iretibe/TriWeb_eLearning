using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TransactionReference)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(o => o.TotalAmount)
                  .HasColumnType("decimal(18,2)");

            builder.HasMany(o => o.Items)
                  .WithOne(oi => oi.Order)
                  .HasForeignKey(oi => oi.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.User)
                  .WithMany() // or .WithMany(u => u.Orders) if you add Orders to ApplicationUser
                  .HasForeignKey(o => o.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
