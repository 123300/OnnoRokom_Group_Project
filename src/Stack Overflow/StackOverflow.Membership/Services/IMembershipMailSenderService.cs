using StackOverflow.Membership.BusinessObjects;

namespace StackOverflow.Membership.Services
{
    public interface IMembershipMailSenderService
    {
        Task SendEmailConfirmationEmailAsync(ApplicationUser user, string verificationCode);
    }
}
