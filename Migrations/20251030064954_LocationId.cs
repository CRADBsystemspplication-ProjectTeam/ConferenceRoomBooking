using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Migrations
{
    /// <inheritdoc />
    public partial class LocationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Locations",
                newName: "Id");
        }
    }
}
