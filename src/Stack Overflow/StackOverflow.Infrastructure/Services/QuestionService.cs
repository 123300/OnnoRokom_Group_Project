using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using StackOverflow.Infrastructure.BusinessObjects;
using QuestionEO = StackOverflow.Infrastructure.Entities.Question;
using StackOverflow.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IStackOverflowUnitOfWork stackOverflowUnitOfWork, IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        public async Task CreateQuestionAsync(Question question)
        {
            if(question is null)
                throw new InvalidOperationException("Question can not be null.");

            var count = await _stackOverflowUnitOfWork.QuestionRepository
                .GetCountAsync(c => c.Title == question.Title);
            if (count != 0)
                throw new DuplicateException("Question with same Title already exist.");

            var questionEnitity = _mapper.Map<QuestionEO>(question);
            await _stackOverflowUnitOfWork.QuestionRepository.AddAsync(questionEnitity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            if (id is 0)
                throw new NullReferenceException("Id must be provided to get Question");

            var questionEntity = (await _stackOverflowUnitOfWork.QuestionRepository
                .GetAsync(c => c.Id == id, x => x.Include(d => d.Tags))).FirstOrDefault();
            if(questionEntity is null)
                throw new InvalidOperationException("Question table not found");

            return _mapper.Map<Question>(questionEntity);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            if (question is null)
                throw new InvalidOperationException("Question can not be null.");

            var count = await _stackOverflowUnitOfWork.QuestionRepository
                .GetCountAsync(c => c.Title == question.Title);
            if (count != 0)
                throw new DuplicateException("Question with same Title already exist.");

            var questionEntity = GetByIdAsync(question.Id);
            if (questionEntity is null)
                throw new InvalidOperationException("Question table not found");

            questionEntity = _mapper.Map(question, questionEntity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            if (id is 0)
                throw new NullReferenceException("Id must be provided to delete Question");

            var questionEntity = (await _stackOverflowUnitOfWork.QuestionRepository
                .GetAsync(c => c.Id == id, x => x.Include(d => d.Tags)
                .Include(y => y.Answers))).FirstOrDefault();
            if(questionEntity is null)
                throw new NullReferenceException("Question Table not found");

            await _stackOverflowUnitOfWork.QuestionRepository.RemoveAsync(questionEntity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }

        //public async Task GetQuestionsAsync()
        //{

        //}

    }
}
