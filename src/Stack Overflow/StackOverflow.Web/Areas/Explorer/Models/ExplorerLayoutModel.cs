using AutoMapper;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Areas.Explorer.Models
{
    public class ExplorerLayoutModel : BaseModel
    {
        public ExplorerLayoutModel()
        {

        }

        public ExplorerLayoutModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter, 
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
			: base(userManagerAdapter, httpContextAccessor, mapper)
        {

        }
    }
}
