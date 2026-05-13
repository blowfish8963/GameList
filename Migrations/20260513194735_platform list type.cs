using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class platformlisttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Games_GameId",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_GameId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Platforms");

            migrationBuilder.AddColumn<List<string>>(
                name: "Platforms",
                table: "Games",
                type: "text[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platforms",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Platforms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_GameId",
                table: "Platforms",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Games_GameId",
                table: "Platforms",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
