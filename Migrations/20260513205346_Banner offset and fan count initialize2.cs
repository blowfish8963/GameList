using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class Banneroffsetandfancountinitialize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BannerOffset",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerOffset",
                table: "Games");
        }
    }
}
