using DevSkill.Http.Utilities;
using DevSkill.Http.Emails.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Templates;

namespace StackOverflow.Membership.Services
{
    public class MembershipMailSenderService : IMembershipMailSenderService
    {
        private IUrlService _urlService;
        private IQueuedEmailService _queuedEmailService;
        private const string confirmationEmailSubject = "Confirmation Email";

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

            var verificationLink = _urlService.GenerateAbsoluteUrl("Account", "ConfirmEmail",
                new { userName = user.UserName, code = verificationCode, area = "" });

            //var accountConfirmationEmail = new AccountConfirmationMailTemplate(verificationLink);
            //var emailBody = accountConfirmationEmail.TransformText();

            await _queuedEmailService.SendSingleEmailAsync(user.FirstName, user.Email,
                "StackOverflow_Email", "This email has been sent for demo purpose");

        }
    }
}
