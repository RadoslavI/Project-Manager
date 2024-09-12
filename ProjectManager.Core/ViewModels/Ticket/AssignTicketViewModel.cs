using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.ViewModels.Employee;

namespace ProjectManager.Core.ViewModels.Ticket
{
    public class AssignTicketViewModel
    {
        public AssignTicketViewModel()
        {
            Employees = new List<EmployeeIdNameViewModel>();
        }

        [Required]
        public Guid TicketId { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public IEnumerable<EmployeeIdNameViewModel> Employees { get; set; }
    }
}
