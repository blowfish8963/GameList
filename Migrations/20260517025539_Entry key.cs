using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class Entrykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameListEntry",
                table: "GameListEntry");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GameListEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameListEntry",
                table: "GameListEntry",
                column: "GameName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameListEntry",
                table: "GameListEntry");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GameListEntry",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameListEntry",
                table: "GameListEntry",
                column: "Id");
        }
    }
}
