using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class Change3Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductItem4s_ProductId",
                table: "ProductItem4s");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem3s_ProductId",
                table: "ProductItem3s");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem1s_ProductId",
                table: "ProductItem1s");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem4s_ProductId",
                table: "ProductItem4s",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem3s_ProductId",
                table: "ProductItem3s",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem1s_ProductId",
                table: "ProductItem1s",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductItem4s_ProductId",
                table: "ProductItem4s");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem3s_ProductId",
                table: "ProductItem3s");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem1s_ProductId",
                table: "ProductItem1s");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem4s_ProductId",
                table: "ProductItem4s",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem3s_ProductId",
                table: "ProductItem3s",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem1s_ProductId",
                table: "ProductItem1s",
                column: "ProductId");
        }
    }
}
