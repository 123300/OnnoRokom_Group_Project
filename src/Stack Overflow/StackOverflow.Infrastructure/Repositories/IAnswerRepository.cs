using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public interface IAnswerRepository : IRepository<Answer, int, ApplicationDbContext>
    {
    }
}
