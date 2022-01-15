using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddProductItem3AndProductItem4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItem3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzSecondTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSecondTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSecondTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzSecondDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSecondDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSecondDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzThirdTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuThirdTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnThirdTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzThirdDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuThirdDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnThirdDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem3s_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem4s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzPhoneInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuPhoneInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnPhoneInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem4s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem4s_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem3s_ProductId",
                table: "ProductItem3s",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem4s_ProductId",
                table: "ProductItem4s",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItem3s");

            migrationBuilder.DropTable(
                name: "ProductItem4s");
        }
    }
}
