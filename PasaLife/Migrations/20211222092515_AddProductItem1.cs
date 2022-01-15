using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddProductItem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItem1s",
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
                    AzDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescriptionBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzEndDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuEndDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnEndDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem1s_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem1s_ProductId",
                table: "ProductItem1s",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItem1s");
        }
    }
}
