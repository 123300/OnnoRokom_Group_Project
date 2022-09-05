using Autofac;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Models
{
    public class LoginModel : PublicLayoutModel
    {
        private ISignInManagerAdapter<ApplicationUser>? _signInManagerAdapter;

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }

        public LoginModel()
        {

        }

        public LoginModel(ISignInManagerAdapter<ApplicationUser> signInManagerAdapter, IUserManagerAdapter<ApplicationUser> userManagerAdapter)
        {
            _signInManagerAdapter = signInManagerAdapter;
            _userManagerAdapter = userManagerAdapter;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _signInManagerAdapter = _scope.Resolve<ISignInManagerAdapter<ApplicationUser>>();

            base.ResolveDependency(_scope);
        }

        internal async Task SignOutAsync()
        {
            await _signInManagerAdapter!.SignOutAsync();
        }

        internal async Task<SignInResult> PasswordSignInAsync()
        {
            var user = GetMember();
            return await _signInManagerAdapter!.PasswordSignInAsync(user);
        }

        public async Task RedirectByUserRole()
        {
            var roles = await _userManagerAdapter!.GetUserRolesAsync(Email!);
            if (roles.Contains("Admin"))
            {
                this.ReturnUrl = "~/admin/dashboard";
            }
            else
            {
                this.ReturnUrl = "~/store/dashboard";
            }
        }

        private ApplicationUser GetMember()
        {
            var user = new ApplicationUser
            {
                UserName = Email,
                Email = Email,
                RememberMe = RememberMe,
                Password = Password
            };
            return user;
        }
    }
}
