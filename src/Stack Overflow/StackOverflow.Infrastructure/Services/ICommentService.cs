using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface ICommentService
    {
        Task CreateCommentAsync(Comment comment);
    }
}
