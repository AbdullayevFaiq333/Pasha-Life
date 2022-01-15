using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddProductItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProductItem1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsProductItem2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsProductItem3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsProductItem4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsProductItem5",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductItem2s",
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
                    AzTitleBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitleBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitleBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstBoxIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzFirstBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuFirstBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnFirstBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondBoxIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzSecondBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSecondBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSecondBoxInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem2s_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem2s_ProductId",
                table: "ProductItem2s",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItem2s");

            migrationBuilder.AddColumn<bool>(
                name: "IsProductItem1",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProductItem2",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProductItem3",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProductItem4",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProductItem5",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
