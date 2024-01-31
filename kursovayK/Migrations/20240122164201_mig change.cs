using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kursovayK.Migrations
{
    /// <inheritdoc />
    public partial class migchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountSeats",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TotalSum",
                table: "Bookings",
                newName: "Cost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Bookings",
                newName: "TotalSum");

            migrationBuilder.AddColumn<int>(
                name: "AmountSeats",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
