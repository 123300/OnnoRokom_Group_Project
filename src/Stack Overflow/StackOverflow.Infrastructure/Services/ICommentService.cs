using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface ICommentService
    {
        Task CreateCommentAsync(Comment comment);
        Task<int> GetQusnVote(Guid id, int questionId);
        Task<int> GetAnsVote(Guid id, int answerId);
    }
}
