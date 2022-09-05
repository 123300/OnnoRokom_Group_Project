using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public interface IQuestionRepository : IRepository<Question, int, ApplicationDbContext>
    {
    }
}
