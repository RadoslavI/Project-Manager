using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Core.ViewModels.Project;
using ProjectManager.Infrastructure.Data.Entities.Enums;

namespace ProjectManager.Core.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ProjectIdNameViewModel Project { get; set; }

        public DepartmentIdNameViewModel Department { get; set; }

        public EmployeeIdNameViewModel Submitter { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public DateTime Date { get; set; }
    }
}
