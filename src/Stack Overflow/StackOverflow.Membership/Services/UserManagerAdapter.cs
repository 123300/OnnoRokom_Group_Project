using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Membership.Enums;
using ApplicationUserEO = StackOverflow.Infrastructure.Entities.Membership.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.Infrastructure.Exceptions;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;

namespace StackOverflow.Membership.Services
{
    public class UserManagerAdapter : IUserManagerAdapter<ApplicationUser>
    {
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;
        private IMembershipMailSenderService _mailSenderService;
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public UserManagerAdapter(UserManager userManager,
            IMembershipMailSenderService mailSenderService, SignInManager signInManager, IMapper mapper,
            IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _mailSenderService = mailSenderService;
            _signInManager = signInManager;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        private ApplicationUserEO GetSingleEntity(ApplicationUser applicationUser)
        {
            var user = _mapper.Map<ApplicationUserEO>(applicationUser);
            return user;
        }

        private ApplicationUser GetSingleBusinessObj(ApplicationUserEO applicationUser)
        {
            var user = _mapper.Map<ApplicationUser>(applicationUser);
            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password)
        {
            if (applicationUser is null)
                throw new InvalidOperationException("User must be provided to create Member");

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidOperationException("Password must be provided to create member");

            var user = GetSingleEntity(applicationUser);
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return result;

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            await SignInAsync(user);

            if (!roleResult.Succeeded)
                return roleResult;

            await DependentDataAsync(user, applicationUser);

            return result;

        }

        public async Task CreateAccountAsync(ApplicationUser applicationUser, string password)
        {
            var user = GetSingleEntity(applicationUser);
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new InvalidCreationException("Failed to create user account, please try again.");
        }

        private async Task SignInAsync(ApplicationUserEO user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task EmailConfirmationTokenAsync(ApplicationUser appUser)
        {
            var entity = GetSingleEntity(appUser);
            await DependentDataAsync(entity, appUser);
        }

        private async Task DependentDataAsync(ApplicationUserEO user,
            ApplicationUser applicationUser)
        {
            if (user is null)
                throw new InvalidOperationException("Application User must be provided to update Dependent Data");

            await SendVerificationEmail(user, applicationUser);
        }

        private async Task SendVerificationEmail(ApplicationUserEO user, ApplicationUser appUser)
        {
            var verificationCode = await GenerateEmailConfirmationTokenAsync(user);

            await _mailSenderService.SendEmailConfirmationEmailAsync(appUser, verificationCode);
        }

        public bool ConfirmedAccount()
        {
            return _userManager.Options.SignIn.RequireConfirmedAccount;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return null!;
            else
                return GetSingleBusinessObj(user);
        }

        public async Task<string> GetUserIdAsync(ApplicationUser applicationUser)
        {
            var user = GetSingleEntity(applicationUser);
            return await _userManager.GetUserIdAsync(user);
        }

        private async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUserEO user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            if (email is null)
                throw new InvalidOperationException("Id must be provide to get roles");

            var userEntity = await _userManager.FindByEmailAsync(email);
            if (userEntity is null)
                throw new InvalidOperationException("User not found");

            var roles = await _userManager.GetRolesAsync(userEntity);
            return roles;
        }

        public async Task<ApplicationUser> FindByUsernameAsync(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);

            if (user == null)
                return null!;
            else
                return GetSingleBusinessObj(user);
        }

        public async Task<bool> UpdateAccountAsync(ApplicationUser user)
        {
            if (user is null)
                throw new InvalidOperationException("Application user must be provided to update dependent data");

            var userEntity = await _userManager.FindByIdAsync(user.Id.ToString());

            userEntity = _mapper.Map(user, userEntity);
            userEntity.NormalizedEmail = user.Email!.ToUpper();

            var result = await _userManager.UpdateAsync(userEntity);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task SignInAsync(Guid id)
        {
            var userEntity = await _userManager.FindByIdAsync(id.ToString());
            if (userEntity is null)
                throw new InvalidOperationException("application user not found");

            await _signInManager.SignInAsync(userEntity, true);
        }

        public string? GetUserId()
        {
            return _httpContext?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private async Task<ApplicationUserEO> FindUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }
        public async Task<IdentityResult> ChangePassword(string userId, string newPassword,
                                                         string confirmPassword)
        {
            var user = await FindUserIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, newPassword,
                                                                 confirmPassword);
            return result;
        }

        public async Task RolesAsync(string userid, RoleTypes[] types)
        {
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User id must be provide.");

            if (types.Length == 0)
                throw new InvalidOperationException("Role must be provide to assign into user.");

            var user = await FindUserIdAsync(userid);
            var roles = types.Select(a => a.ToString()).ToArray();
            await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
