using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3befe20f-e9ad-4f3f-bfba-29f91c1677dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4deb4ce8-861e-45e8-8600-d97c98d5fedd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f8738ab1-7bc1-477e-a239-ded3fbfee2cf", null, "User", "USER" },
                    { "fddfd541-8a3a-4d2a-ae1f-a0e75dd4e71f", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8738ab1-7bc1-477e-a239-ded3fbfee2cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fddfd541-8a3a-4d2a-ae1f-a0e75dd4e71f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3befe20f-e9ad-4f3f-bfba-29f91c1677dd", null, "User", "USER" },
                    { "4deb4ce8-861e-45e8-8600-d97c98d5fedd", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
