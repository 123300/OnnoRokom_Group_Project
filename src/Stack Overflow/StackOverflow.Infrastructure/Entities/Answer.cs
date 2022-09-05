using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Guid? TempId { get; set; }
        public int? Vote { get; set; }
        public Question? Question { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
