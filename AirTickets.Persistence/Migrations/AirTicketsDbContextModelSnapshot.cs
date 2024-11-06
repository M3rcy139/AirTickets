﻿// <auto-generated />
using System;
using System.Collections.Generic;
using AirTickets.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirTickets.Persistence.Migrations
{
    [DbContext(typeof(AirTicketsDbContext))]
    partial class AirTicketsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirTickets.Persistence.Entities.AircraftEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("TotalBusinessSeats")
                        .HasColumnType("integer");

                    b.Property<int>("TotalEconomySeats")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.CrewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Crews", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.CrewMemberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CrewId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("CrewMembers", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.FlightEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("BusinessClassPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CrewId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("EconomyClassPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("CrewId");

                    b.ToTable("Flights", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.IssueReportEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("IssueReports", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.PaymentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ChangeGiven")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<List<int>>("SeatIds")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.SeatAvailabilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("FlightId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<int>("SeatId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SeatId");

                    b.ToTable("SeatAvailabilities", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.SeatEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftId")
                        .HasColumnType("integer");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.ToTable("Seats", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AircraftModel")
                        .IsRequired()
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SeatId")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftModel");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SeatId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.CrewMemberEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.CrewEntity", "Crew")
                        .WithMany("Members")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.FlightEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.AircraftEntity", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirTickets.Persistence.Entities.CrewEntity", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.PaymentEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.UserEntity", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.SeatAvailabilityEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.FlightEntity", "Flight")
                        .WithMany("SeatAvailabilities")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirTickets.Persistence.Entities.PaymentEntity", "Payment")
                        .WithMany("SeatAvailabilities")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AirTickets.Persistence.Entities.SeatEntity", "Seat")
                        .WithMany("SeatAvailabilities")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Payment");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.SeatEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.AircraftEntity", "Aircraft")
                        .WithMany("Seats")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.TicketEntity", b =>
                {
                    b.HasOne("AirTickets.Persistence.Entities.AircraftEntity", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftModel")
                        .HasPrincipalKey("Model")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirTickets.Persistence.Entities.PaymentEntity", "Payment")
                        .WithMany("Tickets")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirTickets.Persistence.Entities.SeatEntity", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirTickets.Persistence.Entities.UserEntity", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Aircraft");

                    b.Navigation("Payment");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.AircraftEntity", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.CrewEntity", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.FlightEntity", b =>
                {
                    b.Navigation("SeatAvailabilities");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.PaymentEntity", b =>
                {
                    b.Navigation("SeatAvailabilities");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.SeatEntity", b =>
                {
                    b.Navigation("SeatAvailabilities");
                });

            modelBuilder.Entity("AirTickets.Persistence.Entities.UserEntity", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
