﻿using AirTickets.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirTickets.Persistence.Configurations
{
    public class AircraftConfiguration : IEntityTypeConfiguration<AircraftEntity>
    {
        public void Configure(EntityTypeBuilder<AircraftEntity> builder)
        {
            builder.ToTable("Aircrafts");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Model)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.TotalEconomySeats)
                   .IsRequired();

            builder.Property(a => a.TotalBusinessSeats)
                   .IsRequired();

            builder.HasMany(a => a.Seats)
                   .WithOne(s => s.Aircraft)
                   .HasForeignKey(s => s.AircraftId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
