using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kursovayK.Migrations
{
    /// <inheritdoc />
    public partial class newfieldsforclassbooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Bookings",
                newName: "Cost");

            migrationBuilder.AddColumn<int>(
                name: "AmountHours",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountHours",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Bookings",
                newName: "TotalCost");
        }
    }
}
