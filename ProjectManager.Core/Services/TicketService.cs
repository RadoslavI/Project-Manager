﻿using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.ViewModels.Department;
using ProjectManager.Core.ViewModels.Employee;
using ProjectManager.Core.ViewModels.Project;
using ProjectManager.Core.ViewModels.Ticket;
using ProjectManager.Core.ViewModels.Ticket.TicketChange;
using ProjectManager.Core.ViewModels.Ticket.TicketComment;
using ProjectManager.Infrastructure.Data.Common;
using ProjectManager.Infrastructure.Data.Entities;
using ProjectManager.Infrastructure.Data.Entities.Enums;

namespace ProjectManager.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository repo;

        public TicketService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateCommentAsync(string userId, CreateTicketCommentViewModel model)
        {
            var ticket = await repo.All<Ticket>()
                .Where(t => t.IsActive && t.Id == model.TicketId)
                .FirstOrDefaultAsync();

            if(ticket == null)
            {
                throw new NullReferenceException();
            }

            var comment = new TicketComment()
            {
                Message = model.Message,
                CommenterId = userId,
                CreatedOn = DateTime.Now,
                TicketId = model.TicketId
            };

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();
        }

        public async Task CreateTicketAsync(SubmitTicketViewModel model, string submitterId, Guid departmentId)
        {
            var ticket = new Ticket()
            {
                Title = model.Title,
                Description = model.Description,
                DepartmentId = departmentId,
                SubmitterId = submitterId,
                CreatedOn = DateTime.Now,
                ProjectId = model.ProjectId,
                Status = Status.Open,
                Priority = model.Priority,
                IsActive = true
            };

            await repo.AddAsync(ticket);
            await repo.SaveChangesAsync();
        }


        /// <summary>
        /// Edits Ticket and adds changes to Ticket History
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Throws if Ticket doesn't exist</exception>
        public async Task EditTicketAsync(EditTicketViewModel model)
        {
            var ticket = await repo.All<Ticket>()
                .Where(t => t.IsActive)
                .Include(t => t.History)
                .FirstOrDefaultAsync(t => t.Id == model.Id);

            if(ticket == null)
            {
                throw new NullReferenceException();
            }

            if(ticket.Title != model.Title)
            {
                ticket.History.Add(CreateChange(ticket.Id, nameof(ticket.Title), ticket.Title, model.Title));

                ticket.Title = model.Title;
            }

            if(ticket.Priority != model.Priority)
            {
                ticket.History.Add(CreateChange(ticket.Id, nameof(ticket.Priority), ticket.Priority.ToString(), model.Priority.ToString()));

                ticket.Priority = model.Priority;
            }
            
            if(ticket.Status != model.Status)
            {
                ticket.History.Add(CreateChange(ticket.Id, nameof(ticket.Status), ticket.Status.ToString(), model.Status.ToString()));

                ticket.Status = model.Status;
            }

            await repo.SaveChangesAsync();
        }


        /// <summary>
        /// Creates Ticket Change.
        /// </summary>
        /// <param name="ticketId">TicketId</param>
        /// <param name="propery">Changed Property name</param>
        /// <param name="oldValue">Old value of the property</param>
        /// <param name="newValue">New value of the property</param>
        /// <returns>Ticket Change</returns>
        private TicketChange CreateChange(Guid ticketId, string propery, string oldValue, string newValue)
        {
            return new TicketChange()
            {
                Property = propery,
                OldValue = oldValue,
                NewValue = newValue,
                Date = DateTime.Now,
                TicketId = ticketId
            };
        }


        /// <summary>
        /// Gets all active Tickets
        /// </summary>
        /// <returns>Collection of TicketViewModel</returns>
        public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new TicketViewModel()
                {
                    Id = t.Id,
                    Submitter = new EmployeeIdNameViewModel()
                    {
                        Id = t.Submitter.Id,
                        UserName = t.Submitter.UserName
                    },
                    Title = t.Title,
                    Project = new ProjectIdNameViewModel()
                    {
                        Id = t.Project.Id,
                        Name = t.Project.Name
                    },
                    Department = new DepartmentIdNameViewModel()
                    {
                        Id = t.Department.Id,
                        Name = t.Department.Name
                    },
                    Priority = t.Priority,
                    Status = t.Status,
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }


        /// <summary>
        /// Gets details for the Ticket to be edited.
        /// </summary>
        /// <param name="id">TicketId</param>
        /// <returns>Ticket details</returns>
        /// <exception cref="NullReferenceException">Throws if Ticket doesn't exist</exception>
        public async Task<EditTicketViewModel> GetEditDetailsById(Guid id)
        {
            var ticket = await repo.GetByIdAsync<Ticket>(id);

            if(ticket == null)
            {
                throw new NullReferenceException();
            }

            return new EditTicketViewModel()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Priority = ticket.Priority,
                Status = ticket.Status
            };
        }


        /// <summary>
        /// Gets the Count of all active Tickets
        /// </summary>
        /// <returns>Count as int</returns>
        public async Task<int> GetCountAsync()
            => await this.repo.AllReadonly<Ticket>().Where(t => t.IsActive).CountAsync();

        public async Task<TicketDetailsViewModel> GetTicketDetailsByIdAsync(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.Id == id)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.AssignedEmployee)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Commenter)
                .Include(t => t.History)
                .Select(t => new TicketDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    SubmitterId = t.SubmitterId,
                    Submitter = t.Submitter.UserName,
                    CreatedOn = t.CreatedOn,
                    ProjectId = t.ProjectId,
                    Project = t.Project.Name,
                    AssignedEmployeeId = t.AssignedEmployeeId,
                    AssignedEmployee = t.AssignedEmployee.UserName,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    Comments = t.Comments
                        .Where(c => c.IsActive)
                        .Select(c => new TicketCommentViewModel()
                        {
                            Message = c.Message,
                            CreatedOn = c.CreatedOn,
                            CommenterId = c.CommenterId,
                            Commenter = c.Commenter.UserName
                        }).ToList(),
                    History = t.History
                        .Where(c => c.IsActive)
                        .Select(c => new TicketChangeViewModel()
                        {
                            Property = c.Property,
                            OldValue = c.OldValue,
                            NewValue = c.NewValue,
                            ChangedOn = c.Date
                        }).ToList()
                })
                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }


        /// <summary>
        /// Assigns Ticket to Employee
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public async Task AssignTicketAsync(AssignTicketViewModel model)
        {
            var employee = await repo.All<Employee>()
                .Where(e => e.IsActive)
                .Include(e => e.AssignedTickets)
                .FirstOrDefaultAsync(e => e.Id == model.EmployeeId);

            if(employee == null)
            {
                throw new NullReferenceException("Employee doesn't exist!");
            }

            var ticket = await repo.All<Ticket>()
                .Where(t => t.IsActive)
                .Include(t => t.AssignedEmployee)
                .Include(t => t.History)
                .FirstOrDefaultAsync(t => t.Id == model.TicketId);

            if(ticket == null)
            {
                throw new NullReferenceException("Ticket doesn't exist!");
            }

            if (employee.AssignedTickets.Contains(ticket))
            {
                throw new ArgumentException("Already assigned to this employee!");
            }

            if(ticket.Status == Status.Done)
            {
                throw new ArgumentException("Ticket is already Done!");
            }

            if(ticket.Status != Status.InProgress)
            {
                var statusChange = CreateChange(
                ticket.Id,
                nameof(ticket.Status),
                ticket.Status.ToString(),
                Status.InProgress.ToString()
                );

                ticket.Status = Status.InProgress;

                ticket.History.Add(statusChange);
            }

            var assignedChange = CreateChange(
                ticket.Id,
                nameof(ticket.AssignedEmployee),
                ticket.AssignedEmployee != null ? ticket.AssignedEmployee.UserName : "Not assigned",
                employee.UserName);

            ticket.AssignedEmployeeId = employee.Id;

            ticket.History.Add(assignedChange);

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive)
                .Select(t => t.Status)
                .ToListAsync();
        }


        /// <summary>
        /// Gets all Tickets with Status - InProgress
        /// </summary>
        /// <returns>Tickets</returns>
        public async Task<IEnumerable<AdminTicketViewModel>> GetInProgressAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.Status == Status.InProgress)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new AdminTicketViewModel()
                {
                    Id = t.Id,
                    Submitter = t.Submitter.UserName,
                    Title = t.Title,
                    Project = t.Project.Name,
                    Department = t.Department.Name,
                    Priority = t.Priority.ToString(),
                    Status = t.Status.ToString(),
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }


        /// <summary>
        /// Gets all Tickets with Status - Done
        /// </summary>
        /// <returns>Tickets</returns>
        public async Task<IEnumerable<AdminTicketViewModel>> GetDoneAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.Status == Status.Done)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new AdminTicketViewModel()
                {
                    Id = t.Id,
                    Submitter = t.Submitter.UserName,
                    Title = t.Title,
                    Project = t.Project.Name,
                    Department = t.Department.Name,
                    Priority = t.Priority.ToString(),
                    Status = t.Status.ToString(),
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }


        /// <summary>
        /// Gets all Tickets with Status - Open
        /// </summary>
        /// <returns>Tickets</returns>
        public async Task<IEnumerable<AdminTicketViewModel>> GetUnassignedAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.Status == Status.Open)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new AdminTicketViewModel()
                {
                    Id = t.Id,
                    Submitter = t.Submitter.UserName,
                    Title = t.Title,
                    Project = t.Project.Name,
                    Department = t.Department.Name,
                    Priority = t.Priority.ToString(),
                    Status = t.Status.ToString(),
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }


        /// <summary>
        /// Gets all innactive Tickets
        /// </summary>
        /// <returns>Tickets</returns>
        public async Task<IEnumerable<AdminTicketViewModel>> GetPastAsync()
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => !t.IsActive)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new AdminTicketViewModel()
                {
                    Id = t.Id,
                    Submitter = t.Submitter.UserName,
                    Title = t.Title,
                    Project = t.Project.Name,
                    Department = t.Department.Name,
                    Priority = t.Priority.ToString(),
                    Status = t.Status.ToString(),
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TicketViewModel>> UserAssignedTicketsAsync(string userId)
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.AssignedEmployeeId == userId)
                .Include(t => t.Submitter)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new TicketViewModel()
                {
                    Id = t.Id,
                    Submitter = new EmployeeIdNameViewModel()
                    {
                        Id = t.Submitter.Id,
                        UserName = t.Submitter.UserName
                    },
                    Title = t.Title,
                    Project = new ProjectIdNameViewModel()
                    {
                        Id = t.Project.Id,
                        Name = t.Project.Name
                    },
                    Department = new DepartmentIdNameViewModel()
                    {
                        Id = t.Department.Id,
                        Name = t.Department.Name
                    },
                    Priority = t.Priority,
                    Status = t.Status,
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TicketViewModel>> UserSubmittedAsync(string userId)
        {
            return await repo.AllReadonly<Ticket>()
                .Where(t => t.IsActive && t.SubmitterId == userId)
                .Include(t => t.Project)
                .Include(t => t.Department)
                .Select(t => new TicketViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Project = new ProjectIdNameViewModel()
                    {
                        Id = t.Project.Id,
                        Name = t.Project.Name
                    },
                    Department = new DepartmentIdNameViewModel()
                    {
                        Id = t.Department.Id,
                        Name = t.Department.Name
                    },
                    Priority = t.Priority,
                    Status = t.Status,
                    Date = t.CreatedOn
                })
                .ToListAsync();
        }
    }
}
