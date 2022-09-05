using Autofac;
using AutoMapper;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.DTOs;
using StackOverflow.Membership.Services;

namespace StackOverflow.Web.Models
{
	public abstract class BaseModel
	{
		protected IUserManagerAdapter<ApplicationUser>? _userManagerAdapter;
		protected IHttpContextAccessor? _httpContextAccessor;
		protected IMapper? _mapper;
		protected ILifetimeScope? _scope;
		public UserBasicInfoDto? UserInfo { get; private set; }
		public BaseModel()
		{

		}

		public BaseModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter, 
						 IHttpContextAccessor httpContextAccessor, 
						 IMapper mapper)
		{
			_userManagerAdapter = userManagerAdapter;
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;
		}

		public virtual void ResolveDependency(ILifetimeScope scope)
		{
			_scope = scope;
			_userManagerAdapter = _scope.Resolve<IUserManagerAdapter<ApplicationUser>>();
			_httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
			_mapper = _scope.Resolve<IMapper>();
		}

		public async virtual Task GetUserInfoAsync()
		{
			var userName = _httpContextAccessor!.HttpContext!.User.Identity!.Name;
			var userInfo = await _userManagerAdapter!.FindByEmailAsync(userName!);
			UserInfo = new UserBasicInfoDto();
			_mapper!.Map(userInfo, UserInfo);
		}

	}
}
