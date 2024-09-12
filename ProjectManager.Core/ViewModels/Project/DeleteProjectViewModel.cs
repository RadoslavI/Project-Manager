namespace ProjectManager.Core.ViewModels.Project
{
    public class DeleteProjectViewModel
    {
        public DeleteProjectViewModel()
        {
            Projects = new List<ProjectIdNameViewModel>();
        }

        public Guid Id { get; set; }

        public IEnumerable<ProjectIdNameViewModel> Projects { get; set; }
    }
}
