using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace StackOverflow.Membership.Services
{
    public interface ISignInManagerAdapter<T> where T : class
    {
        Task<IEnumerable<AuthenticationScheme>> GetExternalSchemesAsync();
        Task SignInAsync(T applicationUser);
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(T user);
    }
}
