using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Game
{
    public partial class AddMapTypeIdToMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapType_MapTypeId",
                table: "Maps");

            migrationBuilder.AlterColumn<Guid>(
                name: "MapTypeId",
                table: "Maps",
                nullable: true,
                oldClrType: typeof(Guid));

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

            migrationBuilder.AlterColumn<Guid>(
                name: "MapTypeId",
                table: "Maps",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_MapType_MapTypeId",
                table: "Maps",
                column: "MapTypeId",
                principalTable: "MapType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
