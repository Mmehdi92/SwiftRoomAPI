using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f538e50-0f82-4051-9924-4365aa7fc3c6", null, "Administrator", "ADMINISTRATOR" },
                    { "b577e092-6610-48d3-a4bc-b20b3039a6bf", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f538e50-0f82-4051-9924-4365aa7fc3c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b577e092-6610-48d3-a4bc-b20b3039a6bf");
        }
    }
}
