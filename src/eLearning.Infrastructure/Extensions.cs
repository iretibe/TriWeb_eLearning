using eLearning.Domain.Helpers;
using eLearning.Domain.Repositories;
using eLearning.Infrastructure.Data;
using eLearning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eLearning.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<eLearningContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("eLearningContext"),
                    b => b.MigrationsAssembly(typeof(eLearningContext).Assembly.FullName)
                ));

            // Register the repository
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVideoContentService, VideoContentService>();
            services.AddScoped<ICourseReviewService, CourseReviewService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
