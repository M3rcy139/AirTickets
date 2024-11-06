using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTickets.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Payments");

            migrationBuilder.AddColumn<List<int>>(
                name: "SeatIds",
                table: "Payments",
                type: "integer[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatIds",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
