using AirTickets.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class SeatAvailabilityConfiguration : IEntityTypeConfiguration<SeatAvailability>
    {
        public void Configure(EntityTypeBuilder<SeatAvailability> builder)
        {
            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.IsAvailable)
                   .IsRequired();

            // Связь с Seat
            builder.HasOne(sa => sa.Seat)
                   .WithMany(s => s.SeatAvailabilities)
                   .HasForeignKey(sa => sa.SeatId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь с Flight
            builder.HasOne(sa => sa.Flight)
                   .WithMany(f => f.SeatAvailabilities)
                   .HasForeignKey(sa => sa.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Связь с Payment (опционально)
            builder.HasOne(sa => sa.Payment)
                   .WithMany()
                   .HasForeignKey(sa => sa.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
