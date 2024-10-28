using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class CrewMemberConfiguration : IEntityTypeConfiguration<CrewMemberEntity>
    {
        public void Configure(EntityTypeBuilder<CrewMemberEntity> builder)
        {
            builder.ToTable("CrewMembers");

            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cm => cm.Position)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(cm => cm.Crew)
               .WithMany(c => c.Members)
               .HasForeignKey(cm => cm.CrewId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
