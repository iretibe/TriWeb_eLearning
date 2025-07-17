using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eLearning.Infrastructure.Data
{
    internal class eLearningContextFactory : IDesignTimeDbContextFactory<eLearningContext>
    {
        public eLearningContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<eLearningContext>();
            optionsBuilder.UseSqlServer("Server=xxx;Database=DMA_eLearning_DB;User ID=sa;Password=xxx;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new eLearningContext(optionsBuilder.Options);
        }
    }
}
