using Microsoft.AspNetCore.Identity;
using StackOverflow.Membership.Enums;

namespace StackOverflow.Membership.Services
{
    public interface IUserManagerAdapter<T> where T : class
    {
        Task<IdentityResult> CreateAsync(T applicationUser, string password);
        Task CreateAccountAsync(T applicationUser, string password);
        bool ConfirmedAccount();
        Task<T> FindByEmailAsync(string email);
        Task<string> GetUserIdAsync(T applicationUser);
        Task EmailConfirmationTokenAsync(T appUser);
        Task<IList<string>> GetUserRolesAsync(string userName);
        Task<bool> UpdateAccountAsync(T user);
        Task SignInAsync(Guid id);
        string? GetUserId();
        Task<IdentityResult> ChangePassword(string userId, string newPassword,
                                            string confirmPassword);
        Task RolesAsync(string userid, RoleTypes[] types);
    }
}
