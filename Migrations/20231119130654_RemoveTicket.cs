using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Tickets_TicketId",
                table: "OrderedItems");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "OrderedItems",
                newName: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Bookings_BookingId",
                table: "OrderedItems",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Bookings_BookingId",
                table: "OrderedItems");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "OrderedItems",
                newName: "TicketId");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatePrinted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Tickets_TicketId",
                table: "OrderedItems",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
