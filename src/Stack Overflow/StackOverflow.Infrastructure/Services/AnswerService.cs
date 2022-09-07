using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using StackOverflow.Infrastructure.BusinessObjects;
using AnswerEO = StackOverflow.Infrastructure.Entities.Answer;

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

        private AnswerEO MappingToEntity(Answer answer)
        {
            var entity = new AnswerEO
            {
                AuthorName = answer.AuthorName,
                Description = answer.Description,
                QuestionId = answer.QuestionId,
                TempId = answer.TempId
            };
            return entity;
        }
        
        public async Task CreateAnswerAsync(Answer answer )
        {
            if (answer is null)
                throw new InvalidOperationException("Answer can not be null.");

            var answerEnitity = MappingToEntity(answer);
            await _stackOverflowUnitOfWork.AnswerRepository.AddAsync(answerEnitity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }
    }
}
