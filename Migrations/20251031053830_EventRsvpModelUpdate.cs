using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceRoomBooking.Migrations
{
    /// <inheritdoc />
    public partial class EventRsvpModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_EventRSVPs_EventId",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "InterestedUserIds",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "MaybeUserIds",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "NotInterestedUserIds",
                table: "EventRSVPs");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "EventRSVPs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EventRSVPs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EventRSVPs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_EventRSVPs_EventId_UserId",
                table: "EventRSVPs",
                columns: new[] { "EventId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRSVPs_UserId",
                table: "EventRSVPs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRSVPs_Users_UserId",
                table: "EventRSVPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRSVPs_Users_UserId",
                table: "EventRSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_EventRSVPs_EventId_UserId",
                table: "EventRSVPs");

            migrationBuilder.DropIndex(
                name: "IX_EventRSVPs_UserId",
                table: "EventRSVPs");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EventRSVPs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "InterestedUserIds",
                table: "EventRSVPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaybeUserIds",
                table: "EventRSVPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotInterestedUserIds",
                table: "EventRSVPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EventRSVPs_EventId",
                table: "EventRSVPs",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
