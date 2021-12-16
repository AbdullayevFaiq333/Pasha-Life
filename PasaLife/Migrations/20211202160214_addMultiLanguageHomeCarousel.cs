using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class addMultiLanguageHomeCarousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "HomeCarousels",
                newName: "RuTitle");

            migrationBuilder.AddColumn<string>(
                name: "AzTitle",
                table: "HomeCarousels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnTitle",
                table: "HomeCarousels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AzTitle",
                table: "HomeCarousels");

            migrationBuilder.DropColumn(
                name: "EnTitle",
                table: "HomeCarousels");

            migrationBuilder.RenameColumn(
                name: "RuTitle",
                table: "HomeCarousels",
                newName: "Title");
        }
    }
}
