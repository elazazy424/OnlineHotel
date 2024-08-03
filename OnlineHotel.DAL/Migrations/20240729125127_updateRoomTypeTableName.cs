using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineHotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateRoomTypeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_roomTypes",
                table: "roomTypes");

            migrationBuilder.RenameTable(
                name: "roomTypes",
                newName: "RoomTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "roomTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roomTypes",
                table: "roomTypes",
                column: "Id");
        }
    }
}
