using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public class AnswerRepository : Repository<Answer, int, ApplicationDbContext>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
