using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class RemoveRelationsAndAddHasDataFromAwardSeoAndHomeCarouselSeosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_AwardSeos_AwardSeoId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarousels_HomeCarouselSeos_HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarousels_HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardSeoId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "HomeCarouselSeoId",
                table: "HomeCarousels");

            migrationBuilder.DropColumn(
                name: "AwardSeoId",
                table: "Awards");

            migrationBuilder.InsertData(
                table: "AwardSeos",
                columns: new[] { "Id", "AzSeoDescription", "AzSeoTitle", "EnSeoDescription", "EnSeoTitle", "RuSeoDescription", "RuSeoTitle" },
                values: new object[] { 1, null, "Mükafat Seo Başlıq", null, null, null, null });

            migrationBuilder.InsertData(
                table: "HomeCarouselSeos",
                columns: new[] { "Id", "AzSeoTitle", "EnSeoTitle", "RuSeoTitle" },
                values: new object[] { 1, "HomeCarousel Seo Başlıq", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AwardSeos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeCarouselSeos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "HomeCarouselSeoId",
                table: "HomeCarousels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwardSeoId",
                table: "Awards",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
