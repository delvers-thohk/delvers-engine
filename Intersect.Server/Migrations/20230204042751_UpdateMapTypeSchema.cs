using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Game
{
    public partial class UpdateMapTypeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PvpEnabled",
                table: "MapType",
                newName: "CanLoseItems");

            migrationBuilder.AddColumn<int>(
                name: "PvpType",
                table: "MapType",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PvpType",
                table: "MapType");

            migrationBuilder.RenameColumn(
                name: "CanLoseItems",
                table: "MapType",
                newName: "PvpEnabled");
        }
    }
}
