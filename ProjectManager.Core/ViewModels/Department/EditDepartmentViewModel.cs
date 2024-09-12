using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.Constants;
using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Core.ViewModels.Department
{
    public class EditDepartmentViewModel
    {
        public EditDepartmentViewModel()
        {
            Employees = new List<EmployeeIdNameViewModel>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(DepartmentConstants.NameMaxLength,
            MinimumLength = DepartmentConstants.NameMinLength)]
        [RegularExpression(ValidationRegex.PropertyRegex,
            ErrorMessage = "Contains unallowed characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Leader")]
        public string LeadId { get; set; }

        public IEnumerable<EmployeeIdNameViewModel> Employees { get; set; }
    }
}
