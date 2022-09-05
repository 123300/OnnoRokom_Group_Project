using StackOverflow.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int? Vote { get; set; }
        public string? Title { get; set; }
        public string? QuestionBody { get; set; }
        public string? Tags { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public IList<Answer>? Answers { get; set; }
        public IList<Comment>? Comments { get; set; }

    }
}
