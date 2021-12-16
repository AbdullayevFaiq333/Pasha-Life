using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddVacancyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyDetails_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyDetails_VacancyId",
                table: "VacancyDetails",
                column: "VacancyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyDetails");

            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
