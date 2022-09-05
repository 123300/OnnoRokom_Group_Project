using DevSkill.Data;
using StackOverflow.Infrastructure.BusinessObjects.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Question
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int? Vote { get; set; }
        public bool IsVoteDone { get; set; }
        public string? Title { get; set; }
        public string? QuestionBody { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsSolvedQstn { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public IList<Tag>? Tags { get; set; }
        public IList<Answer>? Answers { get; set; }

    }
}
