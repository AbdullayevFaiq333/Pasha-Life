using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddCareerImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "preview.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);
        }
    }
}
