namespace ProjectManager.Core.ViewModels.Department
{
    public class DeleteDepartmentViewModel
    {
        public DeleteDepartmentViewModel()
        {
            Departments = new List<DepartmentIdNameViewModel>();
        }

        public Guid Id { get; set; }

        public IEnumerable<DepartmentIdNameViewModel> Departments { get; set; }
    }
}
