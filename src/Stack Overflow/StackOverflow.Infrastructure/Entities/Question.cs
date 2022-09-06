using DevSkill.Data;
using StackOverflow.Infrastructure.Entities.Membership;

namespace StackOverflow.Infrastructure.Entities
{
    public class Question : IEntity<int>
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string? Title { get; set; }
        public int? TotalQutnVote { get; set; }
        public string? QuestionBody { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsSolvedQstn { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public IList<Tag>? Tags { get; set; }
        public IList<Answer>? Answers { get; set; }

    }
}
