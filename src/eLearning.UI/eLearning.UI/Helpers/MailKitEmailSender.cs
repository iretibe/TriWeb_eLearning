using eLearning.UI.Data;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace eLearning.UI.Helpers
{
    public class MailKitEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly EmailSettings _emailSettings;

        public MailKitEmailSender(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            string subject = "Reset your password";
            string htmlMessage = $"Please reset your password by <a href='{resetLink}'>clicking here</a>.";
            await SendEmailAsync(user, email, subject, htmlMessage);
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string code)
        {
            string subject = "Your Password Reset Code";
            string htmlMessage = $"Your password reset code is: <strong>{code}</strong>";
            await SendEmailAsync(user, email, subject, htmlMessage);
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            string subject = "Confirm your email";
            string htmlMessage = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.";
            await SendEmailAsync(user, email, subject, htmlMessage);
        }

        public async Task SendEmailAsync(ApplicationUser user, string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = htmlMessage };
            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, _emailSettings.UseSSL);
            await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
