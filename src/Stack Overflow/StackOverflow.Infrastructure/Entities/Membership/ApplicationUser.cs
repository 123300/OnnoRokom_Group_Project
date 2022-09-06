using Microsoft.AspNetCore.Identity;

namespace StackOverflow.Infrastructure.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsQutnVoteDone { get; set; }
        public bool IsAnsVoteDone { get; set; }
        public IList<Question>? Questions { get; set; }
    }
}
