using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataBaseWithAppointmentAndRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "RoomId", "ShortName" },
                values: new object[,]
                {
                    { 1, "Conference Room A", null, "R A" },
                    { 2, "Conference Room B", null, " R B " }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Begin", "Description", "End", "RoomId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), "Bespreking van overname praktijk", new DateTime(2023, 6, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afspraak Dokter met Piet" },
                    { 2, new DateTime(2023, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bespreking Aaandelen bla bla", new DateTime(2023, 6, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, "Afspraak Bank met Jan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
