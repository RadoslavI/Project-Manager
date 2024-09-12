using Microsoft.AspNetCore.Identity;
using ProjectManager.Core.ViewModels.Admin;

namespace ProjectManager.Core.Contracts
{
    public interface IAdminService
    {
        /// <summary>
        /// Gets all Role Names
        /// </summary>
        /// <returns>List<string> containing all Role Names</returns>
        Task<IEnumerable<string>> GetAllRolesAsync();


        /// <summary>
        /// Creates new IdentityRole
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> CreateRoleAsync(CreateRoleViewModel model);


        /// <summary>
        /// Adds an Employee to a Role
        /// </summary>
        /// <param name="userName">Employee's UserName</param>
        /// <param name="roleName">RoleName</param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> AddToRoleAsync(string userName, string roleName);


        /// <summary>
        /// Assigns an Employee to a Project
        /// </summary>
        /// <param name="employeeId">EmployeeId</param>
        /// <param name="projectId">ProjectId</param>
        /// <returns></returns>
        Task AssignToProjectAsync(string employeeId, Guid projectId);


        /// <summary>
        /// Assigns an Employee to a Department
        /// </summary>
        /// <param name="employeeId">EmployeeId</param>
        /// <param name="departmentId">ProjectId</param>
        /// <returns></returns>
        Task AssignToDepartmentAsync(string employeeId, Guid departmentId);
    }
}
