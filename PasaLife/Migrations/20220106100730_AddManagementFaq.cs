using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddManagementFaq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagementFaqs",
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
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    ManagementCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementFaqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementFaqs_ManagementCategories_ManagementCategoryId",
                        column: x => x.ManagementCategoryId,
                        principalTable: "ManagementCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ManagementCategories",
                columns: new[] { "Id", "AzName", "EnName", "IsDeactive", "RuName" },
                values: new object[] { 3, "Digər komitələr", "Other committees", false, "Другие комитеты" });

            migrationBuilder.CreateIndex(
                name: "IX_ManagementFaqs_ManagementCategoryId",
                table: "ManagementFaqs",
                column: "ManagementCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagementFaqs");

            migrationBuilder.DeleteData(
                table: "ManagementCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
