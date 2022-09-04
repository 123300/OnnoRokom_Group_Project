using DevSkill.Http.Utilities;
using DevSkill.Http.Emails.Services;
using StackOverflow.Membership.BusinessObjects;

namespace StackOverflow.Membership.Services
{
    public class MembershipMailSenderService : IMembershipMailSenderService
    {
        private IUrlService _urlService;
        private IQueuedEmailService _queuedEmailService;

        public MembershipMailSenderService(IUrlService urlService, IQueuedEmailService queuedEmailService)
        {
            _urlService = urlService;
            _queuedEmailService = queuedEmailService;
        }

        public async Task SendEmailConfirmationEmailAsync(ApplicationUser user, string verificationCode)
        {
            if (user is null ||
                string.IsNullOrWhiteSpace(verificationCode))
            {
                throw new InvalidOperationException("User with valid email and verification code must be provided");
            }

            _urlService.GenerateAbsoluteUrl("Account", "ConfirmEmail",
                new { userName = user.UserName, code = verificationCode, area = "" });

            await _queuedEmailService.SendSingleEmailAsync(user.FirstName, user.Email,
                "DemoEmail", "This email has been sent for demo purpose");

        }
    }
}
