namespace ProjectManager.Core.ViewModels.Project
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Department { get; set; } = null!;

        public int AssignedEmployeesCount { get; set; }

        public int TicketsCount { get; set; }
    }
}
