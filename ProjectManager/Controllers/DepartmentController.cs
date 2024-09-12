using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Infrastructure.Data.Entities.Enums;

namespace ProjectManager.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;
        private readonly IEmployeeService employeeService;

        public DepartmentController(
            IDepartmentService _departmentService,
            IEmployeeService _employeeService)
        {
            departmentService = _departmentService;
            employeeService = _employeeService;
        }

        public async Task<IActionResult> All()
        {
            var model = await departmentService.GetAllAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var model = await departmentService.GetDepartmentDetailsAsync(id);

            if(model == null)
            {
                return RedirectToAction(nameof(HomeController.NotFound), "Home");
            }

            ViewData["Open"] = model.Tickets.Where(t => t.Status == Status.Open).Count();
            ViewData["InProgress"] = model.Tickets.Where(t => t.Status == Status.InProgress).Count();
            ViewData["Done"] = model.Tickets.Where(t => t.Status == Status.Done).Count();

            return View(model);
        }
    }
}
