using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Game
{
    public partial class AddMapType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZoneType",
                table: "Maps");

            migrationBuilder.AddColumn<Guid>(
                name: "MapTypeId",
                table: "Maps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MapType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeCreated = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanternVisibilityLevel = table.Column<int>(nullable: false),
                    NametagVisibilityLevel = table.Column<int>(nullable: false),
                    PvpEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MapTypeId",
                table: "Maps",
                column: "MapTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_MapType_MapTypeId",
                table: "Maps",
                column: "MapTypeId",
                principalTable: "MapType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapType_MapTypeId",
                table: "Maps");

            migrationBuilder.DropTable(
                name: "MapType");

            migrationBuilder.DropIndex(
                name: "IX_Maps_MapTypeId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "MapTypeId",
                table: "Maps");

            migrationBuilder.AddColumn<int>(
                name: "ZoneType",
                table: "Maps",
                nullable: false,
                defaultValue: 0);
        }
    }
}
