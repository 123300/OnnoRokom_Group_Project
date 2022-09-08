using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public interface IVoteRepository : IRepository<Vote, int, ApplicationDbContext>
    {
    }
}
