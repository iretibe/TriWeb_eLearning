using eLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLearning.Infrastructure.Configurations
{
    public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
    {
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RecipientEmail).IsRequired();
            builder.Property(e => e.Subject).IsRequired();
            builder.Property(e => e.Body).IsRequired();
        }
    }
}
