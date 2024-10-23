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

            builder.Property(f => f.FlightNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(f => f.DepartureDateTime)
                   .IsRequired();

            builder.Property(f => f.EconomyClassPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(f => f.BusinessClassPrice)
                   .HasColumnType("decimal(18,2)");

            // Один рейс имеет один самолет
            builder.HasOne(f => f.Aircraft)
                   .WithMany()
                   .HasForeignKey(f => f.AircraftId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Один рейс имеет один экипаж
            builder.HasOne(f => f.Crew)
                   .WithMany()
                   .HasForeignKey(f => f.CrewId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Один рейс имеет много мест
            builder.HasMany(f => f.Seats)
                   .WithOne(s => s.Flight)
                   .HasForeignKey(s => s.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
