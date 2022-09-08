using DevSkill.Data;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.Repositories
{
    public class VoteRepository : Repository<Vote, int, ApplicationDbContext>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
