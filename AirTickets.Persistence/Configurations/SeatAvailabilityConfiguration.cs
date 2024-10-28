using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class SeatAvailabilityConfiguration : IEntityTypeConfiguration<SeatAvailabilityEntity>
    {
        public void Configure(EntityTypeBuilder<SeatAvailabilityEntity> builder)
        {
            builder.ToTable("SeatAvailabilities");

            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.IsAvailable)
                   .IsRequired();

            builder.HasOne(sa => sa.Seat)
                   .WithMany(s => s.SeatAvailabilities)
                   .HasForeignKey(sa => sa.SeatId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Flight)
                   .WithMany(f => f.SeatAvailabilities)
                   .HasForeignKey(sa => sa.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Payment)
                   .WithMany(p => p.SeatAvailabilities)
                   .HasForeignKey(sa => sa.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
