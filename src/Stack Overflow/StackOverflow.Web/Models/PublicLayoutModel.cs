using AutoMapper;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;

namespace StackOverflow.Web.Models
{
	public class PublicLayoutModel:BaseModel
	{
		public PublicLayoutModel()
		{
		}

		public PublicLayoutModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
			IHttpContextAccessor httpContextAccessor,IMapper mapper)
			: base(userManagerAdapter, httpContextAccessor,mapper)
		{
		}
	}
}
