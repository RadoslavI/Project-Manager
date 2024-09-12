using ProjectManager.Core.Constants;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Services;
using ProjectManager.Infrastructure.Data.Common;

namespace ProjectManager.Extensions
{
    public static class ProjectManagerServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanAssignAndEditTicket", policy =>
                {
                    policy.RequireRole(new string[] { RoleConstants.Admin, RoleConstants.DepartmentLead });
                });
            });

            return services;
        }
    }
}
