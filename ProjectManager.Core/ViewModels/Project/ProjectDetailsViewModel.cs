using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Core.ViewModels.Ticket;

namespace ProjectManager.Core.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DepartmentIdNameViewModel Department { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public IEnumerable<TicketViewModel> Tickets { get; set; }
    }
}
