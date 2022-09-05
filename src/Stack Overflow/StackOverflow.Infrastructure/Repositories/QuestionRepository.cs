using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public class QuestionRepository : Repository<Question, int, ApplicationDbContext>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
