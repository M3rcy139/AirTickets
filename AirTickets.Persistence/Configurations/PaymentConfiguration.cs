using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PaymentType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.ChangeGiven)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PaymentTime)
                   .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.SeatAvailabilities)
              .WithOne(sa => sa.Payment)
              .HasForeignKey(sa => sa.PaymentId)
              .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Tickets)
                   .WithOne(t => t.Payment)
                   .HasForeignKey(t => t.PaymentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
