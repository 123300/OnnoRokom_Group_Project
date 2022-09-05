
namespace StackOverflow.Infrastructure.BusinessObjects.Membership
{
    public class ApplicationUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<Question>? Questions { get; set; }
    }
}
