using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Seat)
                   .WithMany() 
                   .HasForeignKey(t => t.SeatId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(t => t.Aircraft)
                   .WithMany() 
                   .HasForeignKey(t => t.AircraftModel)
                   .HasPrincipalKey(a => a.Model) 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Payment)
                   .WithMany(p => p.Tickets) 
                   .HasForeignKey(t => t.PaymentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.RouteName)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(t => t.UserName)
                   .IsRequired()
                   .HasMaxLength(50); 

            builder.Property(t => t.UserSurname)
                   .IsRequired()
                   .HasMaxLength(50); 

            builder.Property(t => t.Class)
                   .IsRequired()
                   .HasMaxLength(20); 

            builder.Property(t => t.DepartureDateTime)
                   .IsRequired();

            builder.Property(t => t.ArrivalDateTime)
                   .IsRequired();

            builder.Property(t => t.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); 
        }
    }
}
