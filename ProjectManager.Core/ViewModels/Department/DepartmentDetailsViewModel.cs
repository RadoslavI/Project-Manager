using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Core.ViewModels.Project;
using ProjectManager.Core.ViewModels.Ticket;

namespace ProjectManager.Core.ViewModels.Department
{
    public class DepartmentDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public EmployeeViewModel Leader { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public IEnumerable<TicketViewModel> Tickets { get; set; }
    }
}
