using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public Guid? TempId { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
