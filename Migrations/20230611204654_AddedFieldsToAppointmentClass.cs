using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldsToAppointmentClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c68c02a-e676-445f-b46d-7b40ecc34aa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef75c212-698b-4528-91d7-a449cb39d67c");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25139862-401e-4b48-b97e-a8a66e7bd3e0", null, "Administrator", "ADMINISTRATOR" },
                    { "6e213399-f083-47d0-8282-5948a1af9399", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25139862-401e-4b48-b97e-a8a66e7bd3e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e213399-f083-47d0-8282-5948a1af9399");

            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c68c02a-e676-445f-b46d-7b40ecc34aa2", null, "User", "USER" },
                    { "ef75c212-698b-4528-91d7-a449cb39d67c", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
