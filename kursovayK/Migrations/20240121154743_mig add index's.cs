using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kursovayK.Migrations
{
    /// <inheritdoc />
    public partial class migaddindexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hour",
                table: "HoursForBooking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoursForBooking_Date_SeatId_Hour",
                table: "HoursForBooking",
                columns: new[] { "Date", "SeatId", "Hour" },
                unique: true,
                filter: "[Hour] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HoursForBooking_Date_SeatId_Hour",
                table: "HoursForBooking");

            migrationBuilder.AlterColumn<string>(
                name: "Hour",
                table: "HoursForBooking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
