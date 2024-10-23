using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SeatNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(s => s.Class)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.IsAvailable)
                   .IsRequired();

            builder.HasOne(s => s.Flight)
                   .WithMany(f => f.Seats)
                   .HasForeignKey(s => s.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
