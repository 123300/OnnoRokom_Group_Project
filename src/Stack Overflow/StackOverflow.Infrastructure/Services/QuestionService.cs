using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using StackOverflow.Infrastructure.BusinessObjects;
using QuestionEO = StackOverflow.Infrastructure.Entities.Question;
using TagEO = StackOverflow.Infrastructure.Entities.Tag;
using AnswerEO = StackOverflow.Infrastructure.Entities.Answer;
using StackOverflow.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;
        private int _qtnvote = 0;
        private int _ansvote = 0;

        public QuestionService(IStackOverflowUnitOfWork stackOverflowUnitOfWork, IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        private QuestionEO MappingToEntity(Question question)
        {
            var entity = new QuestionEO
            {
                Id = question.Id,
                ApplicationUserId = question.ApplicationUserId,
                Title = question.Title,
                CreatedAt = question.CreatedAt,
                IsSolvedQstn = question.IsSolvedQstn,
                QuestionBody = question.QuestionBody,
                AuthorName = question.AuthorName
            };
            entity.Tags = new List<TagEO>();
            entity.Answers = new List<AnswerEO>();

            if (question.Tags is not null)
            {
                foreach (var tag in question.Tags)
                {
                    entity.Tags.Add(new TagEO 
                    { 
                        Name = tag.Name,
                        QuestionId = tag.QuestionId,
                        Id = tag.Id
                    });
                }
            }

            if (question.Answers is not null)
            {
                foreach (var answer in question.Answers)
                {
                    entity.Answers.Add(new AnswerEO
                    {
                        Description = answer.Description,
                        Id = answer.Id,
                        AuthorName = answer.AuthorName

                    });
                }
            }
            return entity;
        }

        private Question MappingToBusiness(QuestionEO question)
        {
            var business = new Question
            {
                Id = question.Id,
                ApplicationUserId = question.ApplicationUserId,
                Title = question.Title,
                CreatedAt = question.CreatedAt,
                IsSolvedQstn = question.IsSolvedQstn,
                QuestionBody = question.QuestionBody,
                AuthorName = question.AuthorName,
                Temp1 = _qtnvote,
                Temp2 = _ansvote
                
            };
            business.Tags = new List<Tag>();
            business.Answers = new List<Answer>();

            if(question.Tags is not null)
            {
                foreach (var tag in question.Tags)
                {
                    business.Tags.Add(new Tag 
                    {
                        Name = tag.Name,
                        QuestionId = tag.QuestionId,
                        Id = tag.Id
                    });
                }
            }
            if (question.Answers is not null)
            {
                foreach (var answer in question.Answers)
                {
                    business.Answers.Add(new Answer
                    {
                        Description = answer.Description,
                        Id = answer.Id,
                        AuthorName = answer.AuthorName
                        
                    });
                }
            }

            return business;
            
        }

        public async Task CreateQuestionAsync(Question question)
        {
            if(question is null)
                throw new InvalidOperationException("Question can not be null.");

            var count = await _stackOverflowUnitOfWork.QuestionRepository
                .GetCountAsync(c => c.Title == question.Title);
            if (count != 0)
                throw new DuplicateException("Question with same Title already exist.");

            var questionEnitity = MappingToEntity(question);
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



            return MappingToBusiness(questionEntity);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            if (question is null)
                throw new InvalidOperationException("Question can not be null.");

            var count = await _stackOverflowUnitOfWork.QuestionRepository
                .GetCountAsync(c => c.Title == question.Title);
            if (count != 0)
                throw new DuplicateException("Question with same Title already exist.");

            var questionEntity = (await _stackOverflowUnitOfWork.QuestionRepository
                .GetAsync(c => c.Id == question.Id, x => x.Include(d => d.Tags))).FirstOrDefault();
            if (questionEntity is null)
                throw new InvalidOperationException("Question table not found");
            
            AssignQuestion(question, questionEntity);
            await _stackOverflowUnitOfWork.SaveAsync();
        }

        private QuestionEO AssignQuestion(Question question, QuestionEO questionEO)
        {
            questionEO.Id = question.Id;
            questionEO.ApplicationUserId = question.ApplicationUserId;
            questionEO.Title = question.Title;
            questionEO.CreatedAt = question.CreatedAt;
            questionEO.IsSolvedQstn = question.IsSolvedQstn;
            questionEO.QuestionBody = question.QuestionBody;

            questionEO.Tags = new List<TagEO>();

            if (question.Tags is not null)
            {
                foreach (var tag in question.Tags)
                {
                    questionEO.Tags.Add(new TagEO
                    {
                        Name = tag.Name,
                        QuestionId = tag.QuestionId,
                        Id = tag.Id
                    });
                }
            }
            return questionEO;
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

        public async Task<List<Question>> GetQuestionsAsync(Guid id)
        {
            List<Question> Questions = new List<Question>();

            var QuestionEO = (await _stackOverflowUnitOfWork.QuestionRepository
                .GetAsync(c => c.ApplicationUserId == id, x => x.Include(d => d.Tags)
                .Include(z => z.Answers))).ToList();

            foreach (var question in QuestionEO)
            {
                Questions.Add(MappingToBusiness(question));
            }
            return Questions;
        }

        public void GetTest(int pageIndex)
        {
            var get = _stackOverflowUnitOfWork.QuestionRepository.GetDynamic(null, "Title desc", x => x.Include(c => c.Tags).Include(c => c.Answers), pageIndex, 10);
        }

        public async Task<List<Question>> GetPaginatedQuestions(int index, int pageSize)
        {
            var questionEntites = await _stackOverflowUnitOfWork.QuestionRepository.GetDynamicAsync(null, "Id desc", null, index, pageSize, false);
            var questions = new List<Question>();
            foreach (var question in questionEntites.data)
                questions.Add(_mapper.Map<Question>(question));
            return questions;
        }

        public async Task<Question> GetDetails(int id)
        {
            if (id is 0)
                return null;

            var questionEntity = (await _stackOverflowUnitOfWork.QuestionRepository
                .GetAsync(c => c.Id == id, x => x.Include(d => d.Tags)
                .Include(y => y.Answers))).FirstOrDefault();
            if(questionEntity != null)
            {
                _qtnvote =  (await _stackOverflowUnitOfWork.VoteRepository
                   .GetAsync(c => c.QuestionId == questionEntity.Id, null)).Count();

                if(questionEntity.Answers != null)
                {
                    _ansvote = (await _stackOverflowUnitOfWork.VoteRepository
                   .GetAsync(c => c.AnswerId == questionEntity.Answers.Select(c => c.Id)
                   .FirstOrDefault(), null)).Count();
                }
            }

            return MappingToBusiness(questionEntity);
        }

    }
}
