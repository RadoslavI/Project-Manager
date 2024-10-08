﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Infrastructure.Data.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ProjectConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ProjectConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        public ICollection<EmployeeProject> AssignedEmployees { get; set; } = new List<EmployeeProject>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        [Required]
        public bool IsActive { get; set; }
    }
}
