using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatPriceToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SeatPrice",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatPrice",
                table: "Movies");
        }
    }
}
