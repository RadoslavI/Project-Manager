using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Core.ViewModels.Department
{
    public class ChangeDepartmentViewModel
    {
        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public IEnumerable<DepartmentIdNameViewModel> Departments { get; set; }
    }
}
