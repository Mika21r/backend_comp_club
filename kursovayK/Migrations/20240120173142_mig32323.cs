using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kursovayK.Migrations
{
    /// <inheritdoc />
    public partial class mig32323 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedHours_HourForBookings_HourForBookingId",
                table: "BookedHours");

            migrationBuilder.DropForeignKey(
                name: "FK_HourForBookings_Seats_SeatId",
                table: "HourForBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HourForBookings",
                table: "HourForBookings");

            migrationBuilder.RenameTable(
                name: "HourForBookings",
                newName: "HoursForBooking");

            migrationBuilder.RenameIndex(
                name: "IX_HourForBookings_SeatId",
                table: "HoursForBooking",
                newName: "IX_HoursForBooking_SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoursForBooking",
                table: "HoursForBooking",
                column: "HourForBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedHours_HoursForBooking_HourForBookingId",
                table: "BookedHours",
                column: "HourForBookingId",
                principalTable: "HoursForBooking",
                principalColumn: "HourForBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoursForBooking_Seats_SeatId",
                table: "HoursForBooking",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedHours_HoursForBooking_HourForBookingId",
                table: "BookedHours");

            migrationBuilder.DropForeignKey(
                name: "FK_HoursForBooking_Seats_SeatId",
                table: "HoursForBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoursForBooking",
                table: "HoursForBooking");

            migrationBuilder.RenameTable(
                name: "HoursForBooking",
                newName: "HourForBookings");

            migrationBuilder.RenameIndex(
                name: "IX_HoursForBooking_SeatId",
                table: "HourForBookings",
                newName: "IX_HourForBookings_SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HourForBookings",
                table: "HourForBookings",
                column: "HourForBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedHours_HourForBookings_HourForBookingId",
                table: "BookedHours",
                column: "HourForBookingId",
                principalTable: "HourForBookings",
                principalColumn: "HourForBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HourForBookings_Seats_SeatId",
                table: "HourForBookings",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
