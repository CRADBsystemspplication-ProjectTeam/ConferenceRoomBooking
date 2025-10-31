using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Migrations
{
    /// <inheritdoc />
    public partial class BookingTimeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_Date",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ResourceId_Date_SessionStatus",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId_StartTime_SessionStatus",
                table: "Bookings",
                columns: new[] { "ResourceId", "StartTime", "SessionStatus" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StartTime",
                table: "Bookings",
                column: "StartTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_ResourceId_StartTime_SessionStatus",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StartTime",
                table: "Bookings");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Date",
                table: "Bookings",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId_Date_SessionStatus",
                table: "Bookings",
                columns: new[] { "ResourceId", "Date", "SessionStatus" });
        }
    }
}
