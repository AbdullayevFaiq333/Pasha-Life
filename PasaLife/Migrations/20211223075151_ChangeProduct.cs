using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class ChangeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "ProductItem4s");

            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "ProductItem3s");

            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "ProductItem1s");

            migrationBuilder.AddColumn<bool>(
                name: "ProductItem1",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductItem2",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductItem3",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductItem4",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductItem5",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductItem1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductItem2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductItem3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductItem4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductItem5",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "ProductItem4s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "ProductItem3s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "ProductItem1s",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
