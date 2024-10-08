﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Infrastructure.Data.Entities;
using ProjectManager.Infrastructure.DataConstants;

namespace ProjectManager.Infrastructure.Data.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.LeadedDepartmentId)
                .IsRequired(false);

            builder.Property(e => e.DepartmentId)
                .IsRequired(false);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.LeadedDepartment)
                .WithOne(d => d.Lead)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.Property(e => e.IsGuest)
                .HasDefaultValue(false);

            builder.Property(e => e.UserName)
                .HasMaxLength(EmployeeConstants.UserNameMaxLength);

            builder.Property(e => e.Email)
                .HasMaxLength(EmployeeConstants.EmailMaxLength);

        }
    }
}
