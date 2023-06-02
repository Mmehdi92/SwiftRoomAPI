using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class newmigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fd7f825-1a31-422d-974c-cfffc7333193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9218ddb-09f6-47c0-aa94-08f2eec9f1a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c68c02a-e676-445f-b46d-7b40ecc34aa2", null, "User", "USER" },
                    { "ef75c212-698b-4528-91d7-a449cb39d67c", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c68c02a-e676-445f-b46d-7b40ecc34aa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef75c212-698b-4528-91d7-a449cb39d67c");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApiUserId", "Begin", "Description", "End", "RoomId", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 6, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), "Bespreking van overname praktijk", new DateTime(2023, 6, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afspraak Dokter met Piet" },
                    { 2, null, new DateTime(2023, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bespreking Aaandelen bla bla", new DateTime(2023, 6, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, "Afspraak Bank met Jan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fd7f825-1a31-422d-974c-cfffc7333193", null, "Administrator", "ADMINISTRATOR" },
                    { "e9218ddb-09f6-47c0-aa94-08f2eec9f1a9", null, "User", "USER" }
                });
        }
    }
}
