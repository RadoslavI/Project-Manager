using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProjectManager.Core.ViewModels.Account;

namespace ProjectManager.Core.Contracts
{
    public interface IAccountService
    {
        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Result, indicating wether the operation succeeded or no</returns>
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);


        /// <summary>
        /// Logs In existing user
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Result, indicating wether the operation succeeded or no</returns>
        Task<SignInResult> LoginAsync(LoginViewModel model);


        /// <summary>
        /// Registers new Guest user
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Result, indicating wether the operation succeeded or no</returns>
        Task<IdentityResult> GuestRegisterAsync(GuestRegisterViewModel model);


        /// <summary>
        /// Logs Out the current user.
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        Task LogoutAsync(ClaimsPrincipal user);
    }
}
