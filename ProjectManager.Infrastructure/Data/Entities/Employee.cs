﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Infrastructure.Data.Entities
{
    public class Employee : IdentityUser
    {
        [Required]
        [MaxLength(EmployeeConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(EmployeeConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        public Guid? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        public Guid? LeadedDepartmentId { get; set; }

        [ForeignKey(nameof(LeadedDepartmentId))]
        public Department LeadedDepartment { get; set; }

        public ICollection<EmployeeProject> EmployeesProjects { get; set; } = new List<EmployeeProject>();

        [InverseProperty("Submitter")]
        public ICollection<Ticket> SubmittedTickets { get; set; } = new List<Ticket>();

        [InverseProperty("AssignedEmployee")]
        public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();

        public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();

        [Required]
        public bool IsActive { get; set; }

        public bool IsGuest { get; set; }
    }
}
