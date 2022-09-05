using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Membership.Templates
{
    public partial class AccountConfirmationMailTemplate
    {
        private string VerificationLink { get; set; }

        public AccountConfirmationMailTemplate(string verificationLink)
        {
            VerificationLink = verificationLink;
        }
    }
}
