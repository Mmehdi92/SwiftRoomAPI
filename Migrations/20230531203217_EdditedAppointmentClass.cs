using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class EdditedAppointmentClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f538e50-0f82-4051-9924-4365aa7fc3c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b577e092-6610-48d3-a4bc-b20b3039a6bf");

            migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApiUserId",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7d64e38-1c08-4d31-a8ed-f45fda734557", null, "User", "USER" },
                    { "afce77f1-b2c8-4b5b-849d-bdb2c5c379a9", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApiUserId",
                table: "Appointments",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApiUserId",
                table: "Appointments",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApiUserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApiUserId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d64e38-1c08-4d31-a8ed-f45fda734557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afce77f1-b2c8-4b5b-849d-bdb2c5c379a9");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f538e50-0f82-4051-9924-4365aa7fc3c6", null, "Administrator", "ADMINISTRATOR" },
                    { "b577e092-6610-48d3-a4bc-b20b3039a6bf", null, "User", "USER" }
                });
        }
    }
}
