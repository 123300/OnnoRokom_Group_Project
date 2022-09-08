using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using StackOverflow.Infrastructure.BusinessObjects;
using CommentEO = StackOverflow.Infrastructure.Entities.Comment;
using VoteEO = StackOverflow.Infrastructure.Entities.Vote;

namespace StackOverflow.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;
        private int _qtnvote = 0;
        private int _ansvote = 0;

        public CommentService(IStackOverflowUnitOfWork stackOverflowUnitOfWork, IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        private CommentEO MappingToEntity(Comment comment)
        {
            var entity = new CommentEO
            {
                AnswerId = comment.AnswerId,
                AuthorName = comment.AuthorName,
                CreatedBy = comment.CreatedBy,
                CreatedDate = comment.CreatedDate,
                Description = comment.Description,
                TempId = comment.TempId
            };
            return entity;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            if (comment is null)
                throw new InvalidOperationException("Comment can not be null.");

            var commnetEnitity = MappingToEntity(comment);
            await _stackOverflowUnitOfWork.CommentRepository.AddAsync(commnetEnitity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }

        public async Task<int> GetQusnVote(Guid id, int questionId)
        {
            var vote = new VoteEO()
            {
                ApplicationUserId = id,
                QuestionId = questionId
            };
            var count = await _stackOverflowUnitOfWork.VoteRepository
                .GetCountAsync(c => c.ApplicationUserId == id && c.QuestionId == questionId);

            if(count == 0)
            {

                await _stackOverflowUnitOfWork.VoteRepository.AddAsync(vote);
                await _stackOverflowUnitOfWork.SaveAsync();

                _qtnvote =  (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.QuestionId == questionId,null)).Count();
                return _qtnvote;
            }
            else
            {
                var voteId = (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.QuestionId == questionId && c.ApplicationUserId ==id, null))
                    .Select(c => c.Id).Count();

                if(voteId != 0)
                {
                    await _stackOverflowUnitOfWork.VoteRepository.RemoveAsync(voteId);
                    await _stackOverflowUnitOfWork.SaveAsync();
                }
                _qtnvote = (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.QuestionId == questionId, null)).Count();
                return _qtnvote;
            }
        }

        public async Task<int> GetAnsVote(Guid id, int answerId)
        {
            var vote = new VoteEO()
            {
                ApplicationUserId = id,
                AnswerId = answerId
            };
            var count = await _stackOverflowUnitOfWork.VoteRepository
                .GetCountAsync(c => c.ApplicationUserId == id && c.AnswerId == answerId);

            if (count == 0)
            {

                await _stackOverflowUnitOfWork.VoteRepository.AddAsync(vote);
                await _stackOverflowUnitOfWork.SaveAsync();

                _ansvote = (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.AnswerId == answerId, null)).Count();
                return _ansvote;
            }
            else
            {
                var voteId = (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.AnswerId == answerId && c.ApplicationUserId == id, null))
                    .Select(c => c.Id).Count();

                if (voteId != 0)
                {
                    await _stackOverflowUnitOfWork.VoteRepository.RemoveAsync(voteId);
                    await _stackOverflowUnitOfWork.SaveAsync();
                }
                _ansvote = (await _stackOverflowUnitOfWork.VoteRepository
                    .GetAsync(c => c.QuestionId == answerId, null)).Count();
                return _ansvote;
            }
        }
    }
}
