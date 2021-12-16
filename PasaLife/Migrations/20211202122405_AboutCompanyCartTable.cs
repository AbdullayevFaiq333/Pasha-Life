using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AboutCompanyCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutCompanyItems");

            migrationBuilder.CreateTable(
                name: "AboutCompanyCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Figures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompanyCarts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutCompanyCarts");

            migrationBuilder.CreateTable(
                name: "AboutCompanyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutCompanyId = table.Column<int>(type: "int", nullable: false),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompanyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutCompanyItems_AboutCompanies_AboutCompanyId",
                        column: x => x.AboutCompanyId,
                        principalTable: "AboutCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutCompanyItems_AboutCompanyId",
                table: "AboutCompanyItems",
                column: "AboutCompanyId");
        }
    }
}
