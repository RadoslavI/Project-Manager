namespace ProjectManager.Core.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public int AssignedProjects { get; set; }
        public int AssignedTickets { get; set; }
        public string Email { get; set; }
    }
}
