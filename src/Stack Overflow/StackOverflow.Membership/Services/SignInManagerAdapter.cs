using AutoMapper;
using ApplicationUserEO = StackOverflow.Infrastructure.Entities.Membership.ApplicationUser;
using StackOverflow.Membership.BusinessObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


namespace StackOverflow.Membership.Services
{
    public class SignInManagerAdapter : ISignInManagerAdapter<ApplicationUser>
    {
        private readonly SignInManager _signInManager;
        private IMapper _mapper;

        public SignInManagerAdapter(SignInManager signInManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }

        private ApplicationUserEO GetSingleEntity(ApplicationUser applicationUser)
        {
            var user = _mapper.Map<ApplicationUserEO>(applicationUser);
            return user;
        }

        public async Task<IEnumerable<AuthenticationScheme>> GetExternalSchemesAsync()
        {
            return await _signInManager.GetExternalAuthenticationSchemesAsync();
        }

        public async Task SignInAsync(ApplicationUser applicationUser)
        {
            var user = GetSingleEntity(applicationUser);

            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> PasswordSignInAsync(ApplicationUser user)
        {
            return await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe,
                lockoutOnFailure: false);
        }
    }
}
