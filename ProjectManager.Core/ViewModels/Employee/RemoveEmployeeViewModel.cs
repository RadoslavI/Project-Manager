namespace ProjectManager.Core.ViewModels.Employee
{
    public class RemoveEmployeeViewModel
    {
        public RemoveEmployeeViewModel()
        {
            this.Employees = new List<EmployeeIdNameViewModel>();
        }

        public string Id { get; set; }

        public IEnumerable<EmployeeIdNameViewModel> Employees { get; set; }
    }
}
