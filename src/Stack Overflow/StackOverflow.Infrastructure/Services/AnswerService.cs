using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;

namespace StackOverflow.Infrastructure.Services
{
    public class AnswerService : IAnswerService
    {
        private IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;

        public AnswerService(IStackOverflowUnitOfWork stackOverflowUnitOfWork, IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }
    }
}
