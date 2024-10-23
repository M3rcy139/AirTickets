using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.PassengerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(t => t.PurchaseDate)
                   .IsRequired();

            // Ссылка на рейс
            builder.HasOne(t => t.Flight)
                   .WithMany()
                   .HasForeignKey(t => t.FlightId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Ссылка на место
            builder.HasOne(t => t.Seat)
                   .WithMany()
                   .HasForeignKey(t => t.SeatId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
