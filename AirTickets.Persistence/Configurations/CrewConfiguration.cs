using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<CrewEntity>
    {
        public void Configure(EntityTypeBuilder<CrewEntity> builder)
        {
            builder.HasKey(c => c.Id);

            // Один экипаж имеет много членов экипажа
            builder.HasMany(c => c.Members)
                   .WithOne(cm => cm.Crew)
                   .HasForeignKey(cm => cm.CrewId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
