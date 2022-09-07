using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;

namespace StackOverflow.Web.Areas.Explorer.Models
{
    public class AnswerCreateModel : ExplorerLayoutModel
    {
        private IAnswerService _answerService;
        private ICommentService _commentService;

        public string? Description { get; set; }
        public string? AuthorName { get; set; }
        public int QuestionId { get; set; }
        public Guid? TempId { get; set; }
        public Question? Question { get; set; }
        public IList<Comment>? Comments { get; set; }

        public AnswerCreateModel()
        {

        }

        public AnswerCreateModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor, IMapper mapper,
            IAnswerService answerService, ICommentService commentservice)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _answerService = answerService;
            _commentService = commentservice;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _answerService = _scope.Resolve<IAnswerService>();

            base.ResolveDependency(scope);
        }

        internal async Task AnswerAsync(string answerText, int quesId)
        {
            await GetUserInfoAsync();

            var answer = new Answer()
            {
                Description = answerText,
                AuthorName = UserInfo!.FirstName,
                QuestionId = quesId,
                TempId = UserInfo.Id
            };

            await _answerService.CreateAnswerAsync(answer);
            
        }

        internal async Task CommentAsync(string commentVal, int answerId)
        {
            await GetUserInfoAsync();

            var comment = new Comment()
            {
                 AuthorName = UserInfo!.FirstName,
                 AnswerId = answerId,
                 Description = commentVal,
                 CreatedBy = UserInfo!.FirstName,
                 CreatedDate = DateTime.UtcNow,
                 TempId = UserInfo!.Id
                   
            };

            await _commentService.CreateCommentAsync(comment);

        }

        internal async Task GetQuestionVote(int quesId)
        {
            await GetUserInfoAsync();
            var vote = new Vote()
            {
                ApplicationUserId = UserInfo!.Id,
                QuestionId = quesId
            };

            //await _commentService.CreateCommentAsync(comment);
        }

    }
}
