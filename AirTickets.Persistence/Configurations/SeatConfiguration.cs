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
                   .IsRequired();

            builder.Property(s => s.Class)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Price)
                    .HasColumnType("decimal(18,2)");

            // Связь с Aircraft
            builder.HasOne(s => s.Aircraft)
                   .WithMany(a => a.Seats)
                   .HasForeignKey(s => s.AircraftId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Список доступностей для Seat
            builder.HasMany(s => s.SeatAvailabilities)
                   .WithOne(sa => sa.Seat)
                   .HasForeignKey(sa => sa.SeatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
