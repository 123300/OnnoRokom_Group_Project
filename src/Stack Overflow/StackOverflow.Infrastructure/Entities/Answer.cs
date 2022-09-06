using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSkill.Data;

namespace StackOverflow.Infrastructure.Entities
{
    public class Answer : IEntity<int>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int QuestionId { get; set; }
        public Guid? TempId { get; set; }
        public int? Vote { get; set; }
        public int? TotalAnsVote { get; set; }
        public bool IsVoteDone { get; set; }
        public Question? Question { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
