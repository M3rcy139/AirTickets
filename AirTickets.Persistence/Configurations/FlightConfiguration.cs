using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<FlightEntity>
    {
        public void Configure(EntityTypeBuilder<FlightEntity> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.RouteName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(f => f.DepartureDateTime)
                    .IsRequired();

            builder.Property(f => f.EconomyClassPrice)
                    .HasColumnType("decimal(18,2)");

            builder.Property(f => f.BusinessClassPrice)
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(f => f.Aircraft)
                    .WithMany()
                    .HasForeignKey(f => f.AircraftId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Crew)
                    .WithMany()
                    .HasForeignKey(f => f.CrewId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.SeatAvailabilities)
                    .WithOne(sa => sa.Flight)
                    .HasForeignKey(sa => sa.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
