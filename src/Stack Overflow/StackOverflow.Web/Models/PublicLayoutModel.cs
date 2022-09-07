using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;

namespace StackOverflow.Web.Models
{
	public class PublicLayoutModel:BaseModel
	{
		private IQuestionService _questionService;
		public PublicLayoutModel()
		{
		}

		public PublicLayoutModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
			IHttpContextAccessor httpContextAccessor,IMapper mapper, IQuestionService questionService)
			: base(userManagerAdapter, httpContextAccessor,mapper)
		{
			_questionService = questionService;
		}

		internal async Task<List<Question?>?> GetQuestions(int index)
		{
			var questions = await _questionService.GetPaginatedQuestions(index, 4);
			return questions;
		}
	}
}
