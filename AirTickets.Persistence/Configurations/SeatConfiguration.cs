using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<SeatEntity>
    {
        public void Configure(EntityTypeBuilder<SeatEntity> builder)
        {
            builder.ToTable("Seats");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SeatNumber)
                   .IsRequired();

            builder.Property(s => s.Class)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Price)
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(s => s.Aircraft)
                   .WithMany(a => a.Seats)
                   .HasForeignKey(s => s.AircraftId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SeatAvailabilities)
                   .WithOne(sa => sa.Seat)
                   .HasForeignKey(sa => sa.SeatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
