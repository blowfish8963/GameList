using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class UserGameLists2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUserGameList_UserGameList_GameListsId",
                table: "GameUserGameList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameList",
                table: "UserGameList");

            migrationBuilder.RenameTable(
                name: "UserGameList",
                newName: "UserGameLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameUserGameList_UserGameLists_GameListsId",
                table: "GameUserGameList",
                column: "GameListsId",
                principalTable: "UserGameLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUserGameList_UserGameLists_GameListsId",
                table: "GameUserGameList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists");

            migrationBuilder.RenameTable(
                name: "UserGameLists",
                newName: "UserGameList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameList",
                table: "UserGameList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameUserGameList_UserGameList_GameListsId",
                table: "GameUserGameList",
                column: "GameListsId",
                principalTable: "UserGameList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
