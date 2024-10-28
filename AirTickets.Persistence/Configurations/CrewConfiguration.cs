using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<CrewEntity>
    {
        public void Configure(EntityTypeBuilder<CrewEntity> builder)
        {
            builder.ToTable("Crews");

            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Members)
                   .WithOne(cm => cm.Crew)
                   .HasForeignKey(cm => cm.CrewId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
