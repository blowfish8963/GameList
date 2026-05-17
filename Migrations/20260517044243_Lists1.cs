using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class Lists1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGameListUsername",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserGameListUsername",
                table: "AspNetUsers",
                column: "UserGameListUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserGameLists_UserGameListUsername",
                table: "AspNetUsers",
                column: "UserGameListUsername",
                principalTable: "UserGameLists",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserGameLists_UserGameListUsername",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserGameListUsername",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserGameListUsername",
                table: "AspNetUsers");
        }
    }
}
