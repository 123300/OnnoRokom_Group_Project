using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;

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
    }
}
