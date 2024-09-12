using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Infrastructure.Data.Entities;

namespace ProjectManager.Infrastructure.Data.Configuration
{
    internal class TicketChangeConfiguration : IEntityTypeConfiguration<TicketChange>
    {
        public void Configure(EntityTypeBuilder<TicketChange> builder)
        {
            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);
        }
    }
}
