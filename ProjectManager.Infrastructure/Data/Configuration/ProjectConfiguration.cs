using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Infrastructure.Data.Entities;

namespace ProjectManager.Infrastructure.Data.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);
        }
    }
}
