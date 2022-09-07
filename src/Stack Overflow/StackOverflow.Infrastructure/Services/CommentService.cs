using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using StackOverflow.Infrastructure.BusinessObjects;
using CommentEO = StackOverflow.Infrastructure.Entities.Comment;

namespace StackOverflow.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;

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

        public async Task GetQusnCount()
        {

        }
    }
}
