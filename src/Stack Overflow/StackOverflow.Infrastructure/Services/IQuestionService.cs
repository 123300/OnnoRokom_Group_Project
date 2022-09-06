using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface IQuestionService
    {
        Task CreateQuestionAsync(Question question);
        Task<Question> GetByIdAsync(int id);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
        Task<List<Question>> GetQuestionsAsync(Guid id);
        void GetTest(int pageIndex);
    }
}
