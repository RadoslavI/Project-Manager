using System.ComponentModel.DataAnnotations;
using ProjectManager.Core.Constants;

namespace ProjectManager.Core.ViewModels.Admin
{
    public class CreateRoleViewModel
    {
        [Required]
        [RegularExpression(ValidationRegex.PropertyRegex,
            ErrorMessage = "Contains unallowed characters")]
        public string RoleName { get; set; }
    }
}
