using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Areas.Explorer.Models
{
    public class QuestionCreateModel : ExplorerLayoutModel
    {
        private IQuestionService _questionService;

        public Guid ApplicationUserId { get; set; }

        [Required]
        public string? Title { get; set; }
        public int? TotalQutnVote { get; set; }

        [Required]
        public string? QuestionBody { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsSolvedQstn { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        public IList<string>? Tags { get; set; }
        public IList<Answer>? Answers { get; set; }

        public QuestionCreateModel()
        {

        }

        public QuestionCreateModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor, IMapper mapper, IQuestionService questionService)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _questionService = questionService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _questionService = _scope.Resolve<IQuestionService>();

            base.ResolveDependency(scope);
        }

        internal async Task AddQuestionAsync()
        {
            var question = MapQuestion();
            await _questionService.CreateQuestionAsync(question);
        }

        private Question MapQuestion()
        {
            var question = new Question
            {
                ApplicationUserId = UserInfo!.Id,
                CreatedAt = DateTime.UtcNow,
                Title = Title,
                AuthorName = UserInfo!.FirstName,
                QuestionBody = QuestionBody,
                IsSolvedQstn = false
            };
            question.Tags = new List<Tag>();

            if(Tags!.Count() > 0)
            {
                for (int i = 0; i < Tags!.Count(); i++)
                {
                    question.Tags.Add(new Tag { Name = Tags[i]});
                }
            }
            return question;
            
        }
    }
}
