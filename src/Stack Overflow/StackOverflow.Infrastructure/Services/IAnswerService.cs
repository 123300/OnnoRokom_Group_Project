using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface IAnswerService
    {
        Task CreateAnswerAsync(Answer answer);
    }
}
