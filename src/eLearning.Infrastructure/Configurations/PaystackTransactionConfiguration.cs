using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class PaystackTransactionConfiguration : IEntityTypeConfiguration<PaystackTransaction>
    {
        public void Configure(EntityTypeBuilder<PaystackTransaction> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Reference).IsRequired();
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
