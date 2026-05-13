using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class platformdispalyname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Platforms",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Platforms");
        }
    }
}
