using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Areas.Explorer.Models
{
    public class QuestionEditModel : ExplorerLayoutModel
    {
        private IQuestionService _questionService;

        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }

        [Required]
        public string? Title { get; set; }
        public int? TotalQutnVote { get; set; }

        [Required]
        public string? QuestionBody { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsSolvedQstn { get; set; }
        public string? AuthorName { get; set; }
        public int Temp1 { get; set; }
        public int CountVote { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        public IList<Tag>? Tags { get; set; }
        public IList<Answer>? Answers { get; set; }
        public IList<Question>? Questions { get; set; }

        public QuestionEditModel()
        {

        }

        public QuestionEditModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
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

        internal async Task GetByIdAsyc(int id)
        {
            if(id != 0)
            {
                var question = await _questionService.GetByIdAsync(id);
                if(question != null)
                {
                    Id = question.Id;
                    ApplicationUserId = question.ApplicationUserId;
                    Title = question.Title;
                    CreatedAt = question.CreatedAt;
                    IsSolvedQstn = question.IsSolvedQstn;
                    QuestionBody = question.QuestionBody;
                    AuthorName = question.AuthorName;
                    Tags = new List<Tag>();
                    if(question.Tags != null)
                    {
                        foreach (var tag in question.Tags)
                        {
                            Tags.Add(new Tag
                            { 
                                Name = tag.Name, 
                                Id = tag.Id,
                                QuestionId = tag.QuestionId 
                            });
                        }
                    }
                }
            }
        }

        internal async Task UpdateAsync()
        {
            var question = MapQuestion();
            await _questionService.UpdateQuestionAsync(question);
        }

        private Question MapQuestion()
        {
            var question = new Question
            {
                Id = Id,
                ApplicationUserId = UserInfo!.Id,
                CreatedAt = DateTime.UtcNow,
                Title = Title,
                QuestionBody = QuestionBody,
                IsSolvedQstn = false
            };
            question.Tags = new List<Tag>();

            if (Tags!.Count() > 0)
            {
                for (int i = 0; i < Tags!.Count(); i++)
                {
                    question.Tags.Add(new Tag 
                    { 
                        Name = Tags[i].Name, 
                        QuestionId = Tags[i].QuestionId,
                        Id = Tags[i].Id
                    });
                }
            }
            return question;
        }

        internal async Task DeleteQuestionAsync(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
        }

        internal async Task GetUserSpecificPost()
        {
            await GetUserInfoAsync();
            var user = UserInfo!.Id;

            var questions = await _questionService.GetQuestionsAsync(user);

            Questions = new List<Question>();
            foreach(Question question in questions)
            {
                Questions!.Add(question);
            }

            
        }

        internal void GetTemp()
        {
            _questionService.GetTest(1);
        }

        internal async Task Details(int id)
        {
            var question = await _questionService.GetDetails(id);

            if (question != null)
            {
                Id = question.Id;
                ApplicationUserId = question.ApplicationUserId;
                Title = question.Title;
                CreatedAt = question.CreatedAt;
                QuestionBody = question.QuestionBody;
                Temp1 = question.Temp1;
                AuthorName = question.AuthorName;
                Tags = new List<Tag>();
                Answers = new List<Answer>();
                if (question.Tags != null)
                {
                    foreach (var tag in question.Tags)
                    {
                        Tags.Add(new Tag
                        {
                            Name = tag.Name,
                            Id = tag.Id,
                            QuestionId = tag.QuestionId
                        });
                    }
                }
                if (question.Answers != null)
                {
                    foreach (var answer in question.Answers)
                    {
                        var comment = new List<Comment>();
                        if (answer.Comments != null)
                        {

                            foreach (var com in answer.Comments)
                            {
                                comment.Add(new Comment()
                                {
                                    Description = com.Description,
                                    CreatedDate = com.CreatedDate,
                                    AnswerId = com.AnswerId,
                                    AuthorName = com.AuthorName,
                                    TempId = com.TempId,
                                    CreatedBy = com.CreatedBy
                                });
                            }
                        }
                        Answers.Add(new Answer
                        {
                            Description = answer.Description,
                            Id = answer.Id,
                            AuthorName = answer.AuthorName,
                            CountVote = answer.CountVote,
                            Comments = comment
                        });
                    }
                }
            }


        }
    }
}
