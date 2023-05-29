using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftRoomAPI.Migrations
{
    /// <inheritdoc />
    public partial class EdditRoomClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Rooms_RoomId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomId",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Rooms_RoomId",
                table: "Rooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
