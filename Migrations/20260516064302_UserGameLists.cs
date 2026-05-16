using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class UserGameLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGameList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FavoriteGames = table.Column<List<string>>(type: "text[]", nullable: true),
                    FavoritePlatforms = table.Column<List<string>>(type: "text[]", nullable: true),
                    FavoriteCharacters = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameUserGameList",
                columns: table => new
                {
                    GameListsId = table.Column<int>(type: "integer", nullable: false),
                    GamesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserGameList", x => new { x.GameListsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameUserGameList_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserGameList_UserGameList_GameListsId",
                        column: x => x.GameListsId,
                        principalTable: "UserGameList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameUserGameList_GamesId",
                table: "GameUserGameList",
                column: "GamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameUserGameList");

            migrationBuilder.DropTable(
                name: "UserGameList");
        }
    }
}
