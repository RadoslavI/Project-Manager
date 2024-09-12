using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Core.ViewModels.Admin
{
    public class AssignRolesViewModel
    {
        [Required]
        public string Employee { get; set; }

        [Required]
        public string Role { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();

        public IEnumerable<string> Employees { get; set; } = new List<string>();
    }
}
