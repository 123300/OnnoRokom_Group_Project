using StackOverflow.Infrastructure.BusinessObjects.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Vote
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
    }
}
