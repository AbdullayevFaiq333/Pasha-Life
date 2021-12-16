using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class AddSeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "OnlineServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "NewsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "NewsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "NewsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Managements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Managements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Managements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "ManagementDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "ManagementDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "ManagementDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "InformationCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeCarouselSeoId",
                table: "HomeCarousels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwardSeoId",
                table: "Awards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoDescription",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzSeoTitle",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoDescription",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnSeoTitle",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoDescription",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuSeoTitle",
                table: "AboutCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AwardSeos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzSeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardSeos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarouselSeos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnSeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarouselSeos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarousels_HomeCarouselSeoId",
                table: "HomeCarousels",
                column: "HomeCarouselSeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardSeoId",
                table: "Awards",
                column: "AwardSeoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_AwardSeos_AwardSeoId",
                table: "Awards",
                column: "AwardSeoId",
                principalTable: "AwardSeos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarousels_HomeCarouselSeos_HomeCarouselSeoId",
                table: "HomeCarousels",
                column: "HomeCarouselSeoId",
                principalTable: "HomeCarouselSeos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_AwardSeos_AwardSeoId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarousels_HomeCarouselSeos_HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropTable(
                name: "AwardSeos");

            migrationBuilder.DropTable(
                name: "HomeCarouselSeos");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarousels_HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardSeoId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "OnlineServices");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "NewsDetails");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "NewsDetails");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "NewsDetails");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "News");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Managements");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "ManagementDetail");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "ManagementDetail");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "ManagementDetail");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "InformationCenters");

            migrationBuilder.DropColumn(
                name: "HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "AwardSeoId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AzSeoDescription",
                table: "AboutCompanies");

            migrationBuilder.DropColumn(
                name: "AzSeoTitle",
                table: "AboutCompanies");

            migrationBuilder.DropColumn(
                name: "EnSeoDescription",
                table: "AboutCompanies");

            migrationBuilder.DropColumn(
                name: "EnSeoTitle",
                table: "AboutCompanies");

            migrationBuilder.DropColumn(
                name: "RuSeoDescription",
                table: "AboutCompanies");

            migrationBuilder.DropColumn(
                name: "RuSeoTitle",
                table: "AboutCompanies");
        }
    }
}
