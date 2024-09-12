using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.Constants;
using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Core.ViewModels.Project
{
    public class CreateProjectViewModel
    {
        [Required]
        [StringLength(ProjectConstants.NameMaxLength,
            MinimumLength = ProjectConstants.NameMinLength)]
        [RegularExpression(ValidationRegex.PropertyRegex,
            ErrorMessage = "Contains unallowed characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(ProjectConstants.DescriptionMaxLength,
            MinimumLength = ProjectConstants.DescriptionMinLength)]
        [RegularExpression(ValidationRegex.DescriptionAndMessageRegex,
            ErrorMessage = "Contains unallowed characters")]
        public string Description { get; set; } = null!;

        [Required]
        public Guid DepartmentId { get; set; }

        public IEnumerable<DepartmentIdNameViewModel> Departments { get; set; } 
            = new List<DepartmentIdNameViewModel>();
    }
}
