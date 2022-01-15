using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class Change2Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductItem5",
                table: "Products",
                newName: "IsProductItem5");

            migrationBuilder.RenameColumn(
                name: "ProductItem4",
                table: "Products",
                newName: "IsProductItem4");

            migrationBuilder.RenameColumn(
                name: "ProductItem3",
                table: "Products",
                newName: "IsProductItem3");

            migrationBuilder.RenameColumn(
                name: "ProductItem2",
                table: "Products",
                newName: "IsProductItem2");

            migrationBuilder.RenameColumn(
                name: "ProductItem1",
                table: "Products",
                newName: "IsProductItem1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsProductItem5",
                table: "Products",
                newName: "ProductItem5");

            migrationBuilder.RenameColumn(
                name: "IsProductItem4",
                table: "Products",
                newName: "ProductItem4");

            migrationBuilder.RenameColumn(
                name: "IsProductItem3",
                table: "Products",
                newName: "ProductItem3");

            migrationBuilder.RenameColumn(
                name: "IsProductItem2",
                table: "Products",
                newName: "ProductItem2");

            migrationBuilder.RenameColumn(
                name: "IsProductItem1",
                table: "Products",
                newName: "ProductItem1");
        }
    }
}
