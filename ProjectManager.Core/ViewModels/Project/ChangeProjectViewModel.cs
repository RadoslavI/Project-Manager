using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Core.ViewModels.Project
{
    public class ChangeProjectViewModel
    {
        [Required]
        [Display(Name = "Project")]
        public Guid ProjectId { get; set; }

        public IEnumerable<ProjectIdNameViewModel> Projects { get; set; }
    }
}
