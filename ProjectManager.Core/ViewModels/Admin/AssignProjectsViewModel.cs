using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Core.ViewModels.Project;

namespace ProjectManager.Core.ViewModels.Admin
{
    public class AssignProjectsViewModel
    {
        public AssignProjectsViewModel()
        {
            Employees = new List<EmployeeIdNameViewModel>();
            Projects = new List<ProjectIdNameViewModel>();
        }

        [Required(ErrorMessage = "You must select an Employee")]
        public string EmployeeId { get; set; } = null!;

        public IEnumerable<EmployeeIdNameViewModel> Employees { get; set; }

        [Required(ErrorMessage = "You must select a Project")]
        public Guid ProjectId { get; set; }

        public IEnumerable<ProjectIdNameViewModel> Projects { get; set; }
    }
}
