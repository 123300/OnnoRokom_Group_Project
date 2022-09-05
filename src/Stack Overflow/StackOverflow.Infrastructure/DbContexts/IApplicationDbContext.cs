using Microsoft.EntityFrameworkCore;
using StackOverflow.Infrastructure.Entities;
using StackOverflow.Infrastructure.Entities.Membership;

namespace StackOverflow.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        DbSet<Question>? Questions { get; set; }
        DbSet<Answer>? Answers { get; set; }
        DbSet<Comment>? Comments { get; set; }
        DbSet<Tag>? Tags { get; set; }
    }
}
