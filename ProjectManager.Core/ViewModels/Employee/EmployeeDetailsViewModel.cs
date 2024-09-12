using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Core.ViewModels.Project;
using ProjectManager.Core.ViewModels.Ticket;

namespace ProjectManager.Core.ViewModels.Employee
{
    public class EmployeeDetailsViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DepartmentIdNameViewModel? Department { get; set; }

        public DepartmentIdNameViewModel? LeadedDepartment { get; set; }

        public bool IsLeader { get; set; }

        public ICollection<ProjectIdNameViewModel> Projects { get; set; }

        public ICollection<TicketViewModel> SubmittedTickets { get; set; }

        public ICollection<TicketViewModel> AssignedTickets { get; set; }
    }
}
