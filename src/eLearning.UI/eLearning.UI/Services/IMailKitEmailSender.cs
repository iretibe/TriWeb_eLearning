using eLearning.UI.Data;

namespace eLearning.UI.Services
{
    public interface IMailKitEmailSender
    {
        Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink);
        Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string code);
        Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink);
        Task SendEmailAsync(ApplicationUser user, string email, string subject, string htmlMessage);
    }
}
