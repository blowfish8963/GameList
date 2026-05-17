using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class Listinitializationmeasures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameListEntry_UserGameLists_ListId",
                table: "GameListEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists");

            migrationBuilder.DropIndex(
                name: "IX_GameListEntry_ListId",
                table: "GameListEntry");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGameLists");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "GameListEntry");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserGameLists",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListUsername",
                table: "GameListEntry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_GameListEntry_ListUsername",
                table: "GameListEntry",
                column: "ListUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_GameListEntry_UserGameLists_ListUsername",
                table: "GameListEntry",
                column: "ListUsername",
                principalTable: "UserGameLists",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameListEntry_UserGameLists_ListUsername",
                table: "GameListEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists");

            migrationBuilder.DropIndex(
                name: "IX_GameListEntry_ListUsername",
                table: "GameListEntry");

            migrationBuilder.DropColumn(
                name: "ListUsername",
                table: "GameListEntry");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserGameLists",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGameLists",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "GameListEntry",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameLists",
                table: "UserGameLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameListEntry_ListId",
                table: "GameListEntry",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameListEntry_UserGameLists_ListId",
                table: "GameListEntry",
                column: "ListId",
                principalTable: "UserGameLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
