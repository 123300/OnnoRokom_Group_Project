using DevSkill.Data;
using StackOverflow.Infrastructure.Entities.Membership;

namespace StackOverflow.Infrastructure.Entities
{
    public class Vote : IEntity<int>
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }



    }
}
