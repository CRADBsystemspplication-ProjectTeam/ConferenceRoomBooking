using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Departments_DepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Locations_LocationId",
                table: "BroadcastNotifications");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastNotifications_DepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.DropColumn(
                name: "MaxBookingDuration",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MinBookingDuration",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "NoOfFloors",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "UserOtpVerifications",
                newName: "OtpCode");

            migrationBuilder.RenameColumn(
                name: "ExpiryAt",
                table: "UserOtpVerifications",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "Attempts",
                table: "UserOtpVerifications",
                newName: "AttemptCount");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "UserNotifications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "NotificationSubject",
                table: "UserNotifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "UserNotifications",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "UserNotifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Wifi",
                table: "Rooms",
                newName: "HasWiFi");

            migrationBuilder.RenameColumn(
                name: "Whiteboard",
                table: "Rooms",
                newName: "HasWhiteboard");

            migrationBuilder.RenameColumn(
                name: "VideoConferenceEquipment",
                table: "Rooms",
                newName: "HasVideoConference");

            migrationBuilder.RenameColumn(
                name: "TV",
                table: "Rooms",
                newName: "HasTV");

            migrationBuilder.RenameColumn(
                name: "DigitalProjector",
                table: "Rooms",
                newName: "HasProjector");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Resources",
                newName: "IsBlocked");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "Resources",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "Locations",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Locations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FloorId",
                table: "Floors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventTitle",
                table: "Events",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "DeskId",
                table: "Desks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BuildingName",
                table: "Buildings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Buildings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "BroadcastNotifications",
                newName: "TargetLocationId");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "BroadcastNotifications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "NotificationSubject",
                table: "BroadcastNotifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "BroadcastNotifications",
                newName: "TargetDepartmentId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BroadcastNotifications",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "BroadcastNotifications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BroadcastNotifications_LocationId",
                table: "BroadcastNotifications",
                newName: "IX_BroadcastNotifications_TargetDepartmentId");

            migrationBuilder.RenameColumn(
                name: "CheckInId",
                table: "BookingCheckIns",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserOtpVerifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedAt",
                table: "UserOtpVerifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "UserNotifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "UserNotifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Resources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "FloorNumber",
                table: "Floors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "FloorName",
                table: "Floors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Floors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDockingStation",
                table: "Desks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasKeyboard",
                table: "Desks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMonitor",
                table: "Desks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMouse",
                table: "Desks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Buildings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "BuildingImage",
                table: "Buildings",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloors",
                table: "Buildings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Buildings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedIn",
                table: "BookingCheckIns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "BookingCheckIns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserBookingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalBookings = table.Column<int>(type: "int", nullable: false),
                    CompletedBookings = table.Column<int>(type: "int", nullable: false),
                    CancelledBookings = table.Column<int>(type: "int", nullable: false),
                    NoShowBookings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookingStats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastNotifications_TargetLocationId",
                table: "BroadcastNotifications",
                column: "TargetLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookingStats_UserId",
                table: "UserBookingStats",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Departments_TargetDepartmentId",
                table: "BroadcastNotifications",
                column: "TargetDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BroadcastNotifications_Locations_TargetLocationId",
                table: "BroadcastNotifications",
                column: "TargetLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Departments_TargetDepartmentId",
                table: "BroadcastNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BroadcastNotifications_Locations_TargetLocationId",
                table: "BroadcastNotifications");

            migrationBuilder.DropTable(
                name: "UserBookingStats");

            migrationBuilder.DropIndex(
                name: "IX_BroadcastNotifications_TargetLocationId",
                table: "BroadcastNotifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserOtpVerifications");

            migrationBuilder.DropColumn(
                name: "UsedAt",
                table: "UserOtpVerifications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FloorName",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "HasDockingStation",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "HasKeyboard",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "HasMonitor",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "HasMouse",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "BuildingImage",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "NumberOfFloors",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "IsCheckedIn",
                table: "BookingCheckIns");

            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "BookingCheckIns");

            migrationBuilder.RenameColumn(
                name: "OtpCode",
                table: "UserOtpVerifications",
                newName: "Otp");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "UserOtpVerifications",
                newName: "ExpiryAt");

            migrationBuilder.RenameColumn(
                name: "AttemptCount",
                table: "UserOtpVerifications",
                newName: "Attempts");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserNotifications",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserNotifications",
                newName: "NotificationSubject");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "UserNotifications",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserNotifications",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "HasWiFi",
                table: "Rooms",
                newName: "Wifi");

            migrationBuilder.RenameColumn(
                name: "HasWhiteboard",
                table: "Rooms",
                newName: "Whiteboard");

            migrationBuilder.RenameColumn(
                name: "HasVideoConference",
                table: "Rooms",
                newName: "VideoConferenceEquipment");

            migrationBuilder.RenameColumn(
                name: "HasTV",
                table: "Rooms",
                newName: "TV");

            migrationBuilder.RenameColumn(
                name: "HasProjector",
                table: "Rooms",
                newName: "DigitalProjector");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "IsBlocked",
                table: "Resources",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resources",
                newName: "ResourceId");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Locations",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locations",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Floors",
                newName: "FloorId");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "EventTitle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Desks",
                newName: "DeskId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Buildings",
                newName: "BuildingName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Buildings",
                newName: "BuildingId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "BroadcastNotifications",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BroadcastNotifications",
                newName: "NotificationSubject");

            migrationBuilder.RenameColumn(
                name: "TargetLocationId",
                table: "BroadcastNotifications",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "TargetDepartmentId",
                table: "BroadcastNotifications",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "BroadcastNotifications",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BroadcastNotifications",
                newName: "NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_BroadcastNotifications_TargetDepartmentId",
                table: "BroadcastNotifications",
                newName: "IX_BroadcastNotifications_LocationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingCheckIns",
                newName: "CheckInId");

            migrationBuilder.AddColumn<int>(
                name: "MaxBookingDuration",
                table: "Resources",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinBookingDuration",
                table: "Resources",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FloorNumber",
                table: "Floors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NoOfFloors",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "BroadcastNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BroadcastNotifications_DepartmentId",
                table: "BroadcastNotifications",
                column: "DepartmentId");

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
        }
    }
}
