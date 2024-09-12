using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Core.ViewModels.Employee;

namespace ProjectManager.Core.ViewModels.Admin
{
    public class AssignDepartmentViewModel
    {
        public AssignDepartmentViewModel()
        {
            Employees = new List<EmployeeIdNameViewModel>();
            Departments = new List<DepartmentIdNameViewModel>();
        }

        [Required]
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }

        public IEnumerable<EmployeeIdNameViewModel> Employees { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public IEnumerable<DepartmentIdNameViewModel> Departments { get; set; }
    }
}
