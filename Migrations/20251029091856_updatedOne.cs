using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Migrations
{
    /// <inheritdoc />
    public partial class updatedOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Resources_ResourceId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Departments_DepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Locations_LocationId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRSVPs_Events_EventId1",
                table: "EventRSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Bookings_BookingId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Departments_DepartmentId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Locations_LocationId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_EventRSVPs_EventId1",
                table: "EventRSVPs");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ResourceId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "ResourceId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Departments_DepartmentId",
                table: "BroadcastNotifications",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Locations_LocationId",
                table: "BroadcastNotifications",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Bookings_BookingId",
                table: "UserNotifications",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Departments_DepartmentId",
                table: "UserNotifications",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Locations_LocationId",
                table: "UserNotifications",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Departments_DepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Locations_LocationId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Bookings_BookingId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Departments_DepartmentId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Locations_LocationId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "EventRSVPs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResourceId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRSVPs_EventId1",
                table: "EventRSVPs",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId1",
                table: "Bookings",
                column: "ResourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Resources_ResourceId1",
                table: "Bookings",
                column: "ResourceId1",
                principalTable: "Resources",
                principalColumn: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Departments_DepartmentId",
                table: "BroadcastNotifications",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Locations_LocationId",
                table: "BroadcastNotifications",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRSVPs_Events_EventId1",
                table: "EventRSVPs",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Bookings_BookingId",
                table: "UserNotifications",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Departments_DepartmentId",
                table: "UserNotifications",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Locations_LocationId",
                table: "UserNotifications",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
