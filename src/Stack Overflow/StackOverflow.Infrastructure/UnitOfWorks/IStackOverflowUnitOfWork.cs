using StackOverflow.Infrastructure.Repositories;
using DevSkill.Data;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public interface IStackOverflowUnitOfWork : IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        ICommentRepository CommentRepository { get; }
        IVoteRepository VoteRepository { get; }
    }
}
