using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class addIconToSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IconButtons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: "u.svg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IconButtons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: null);
        }
    }
}
