using DevSkill.Data;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Repositories;
using System;


namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class StackOverflowUnitOfWork : UnitOfWork, IStackOverflowUnitOfWork
    {
        public IQuestionRepository QuestionRepository { get; private set; }
        public IAnswerRepository AnswerRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public IVoteRepository VoteRepository { get; private set; }

        public StackOverflowUnitOfWork(ApplicationDbContext dbContext, 
            IQuestionRepository questionRepository, 
            IAnswerRepository answerRepository,
            ICommentRepository commentRepository,
            IVoteRepository voteRepository)
            :base(dbContext)
        {
            QuestionRepository = questionRepository;
            AnswerRepository = answerRepository;
            CommentRepository = commentRepository;
            VoteRepository = voteRepository;
        }

    }
}
