using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class Gameentries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameUserGameList");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserGameLists",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "GameListEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListId = table.Column<int>(type: "integer", nullable: false),
                    GameName = table.Column<string>(type: "text", nullable: false),
                    EntryStatus = table.Column<string>(type: "text", nullable: false),
                    EntryRating = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameListEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameListEntry_UserGameLists_ListId",
                        column: x => x.ListId,
                        principalTable: "UserGameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameListEntry_ListId",
                table: "GameListEntry",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameListEntry");

            migrationBuilder.AlterColumn<int>(
                name: "Username",
                table: "UserGameLists",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                        name: "FK_GameUserGameList_UserGameLists_GameListsId",
                        column: x => x.GameListsId,
                        principalTable: "UserGameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameUserGameList_GamesId",
                table: "GameUserGameList",
                column: "GamesId");
        }
    }
}
