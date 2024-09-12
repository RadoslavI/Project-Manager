using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Infrastructure.Data.Entities;

namespace ProjectManager.Infrastructure.Data.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.IsActive)
                .HasDefaultValue(true);
        }
    }
}
