﻿using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.ViewModels.Ticket;
using ProjectManager.Infrastructure.Data.Entities.Enums;

namespace ProjectManager.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IDepartmentService departmentService;
        private readonly ITicketService ticketService;

        public ProjectController(
            IProjectService _projectService,
            IDepartmentService _departmentService,
            ITicketService _ticketService)
        {
            projectService = _projectService;
            departmentService = _departmentService;
            ticketService = _ticketService;
        }

        public async Task<IActionResult> All()
        {
            var model = await projectService.GetAllProjectsAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var model = await projectService.GetProjectDetailsByIdAsync(id);

            if (model == null)
            {
                return RedirectToAction(nameof(HomeController.NotFound), "Home");
            }

            ViewData["Open"] = model.Tickets.Where(t => t.Status == Status.Open).Count();
            ViewData["InProgress"] = model.Tickets.Where(t => t.Status == Status.InProgress).Count();
            ViewData["Done"] = model.Tickets.Where(t => t.Status == Status.Done).Count();

            return View(model);
        }

        public async Task<IActionResult> My()
        {
            var model = await projectService.UserProjectsAsync(User.Id());

            return View(model);
        }

        [HttpGet]
        public IActionResult SubmitTicket(Guid id, bool? success)
        {
            var model = new SubmitTicketViewModel();
            model.ProjectId = id;

            ViewBag.Success = success;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTicket(SubmitTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var submitterId = User.Id();

            try
            {
                var project = await projectService.GetProjectDetailsByIdAsync(model.ProjectId);

                await ticketService.CreateTicketAsync(model, submitterId, project.Department.Id);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(SubmitTicket), new { Success = false });
            }

            return RedirectToAction(nameof(Details), new { Id = model.ProjectId });
        }
    }
}
