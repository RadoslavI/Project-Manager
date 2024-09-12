using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.Constants;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Core.ViewModels.Project
{
    public class EditProjectViewModel
    {
        [Required]
        public Guid Id { get; set; }

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
        public string Description { get; set; }

    }
}
