using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameList.Migrations
{
    /// <inheritdoc />
    public partial class newfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Platforms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Platforms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BannerOffset",
                table: "Platforms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseYear",
                table: "Platforms",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseYear",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerOffset",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "BannerUrl",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Platforms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Platforms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Games",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Games",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
