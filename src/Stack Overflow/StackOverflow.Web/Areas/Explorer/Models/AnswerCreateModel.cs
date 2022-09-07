using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Areas.Explorer.Models
{
    public class AnswerCreateModel : ExplorerLayoutModel
    {
        private IAnswerService _answerService;

        public string? Description { get; set; }
        public int QuestionId { get; set; }
        public Guid? TempId { get; set; }
        public int? Vote { get; set; }
        public int? TotalAnsVote { get; set; }
        public bool IsVoteDone { get; set; }
        public Question? Question { get; set; }
        public IList<Comment>? Comments { get; set; }

        public AnswerCreateModel()
        {

        }

        public AnswerCreateModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor, IMapper mapper, IAnswerService answerService)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _answerService = answerService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _answerService = _scope.Resolve<IAnswerService>();

            base.ResolveDependency(scope);
        }

        internal async Task AnswerAsync(string description, int questionId, int totalVote)
        {
            await GetUserInfoAsync();

            bool isAns = UserInfo!.IsAnsVoteDone;
            if(isAns is true)
            {
                TotalAnsVote = totalVote -1;
            }
            TempId = UserInfo!.Id;
            Description = description;
            QuestionId = questionId;
        }
    }
}
