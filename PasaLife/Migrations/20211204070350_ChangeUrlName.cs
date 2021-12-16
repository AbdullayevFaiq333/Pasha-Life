using Microsoft.EntityFrameworkCore.Migrations;

namespace PasaLife.Migrations
{
    public partial class ChangeUrlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 1,
                column: "URL",
                value: "/aboutus");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 2,
                column: "URL",
                value: "/product");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 3,
                column: "URL",
                value: "/onlineservices");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "/informationcenter");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "/career");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 6,
                column: "URL",
                value: "/contact");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 7,
                column: "URL",
                value: "/aboutcompany");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 8,
                column: "URL",
                value: "/management");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 9,
                column: "URL",
                value: "/structure");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 10,
                column: "URL",
                value: "/report");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 11,
                column: "URL",
                value: "/award");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 1,
                column: "URL",
                value: "/AboutUs");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 2,
                column: "URL",
                value: "/Product");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 3,
                column: "URL",
                value: "/OnlineServices");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "/InformationCenter");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "/Career");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 6,
                column: "URL",
                value: "/Contact");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 7,
                column: "URL",
                value: "/AboutCompany");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 8,
                column: "URL",
                value: "/Management");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 9,
                column: "URL",
                value: "/Structure");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 10,
                column: "URL",
                value: "/Report");

            migrationBuilder.UpdateData(
                table: "URLButtons",
                keyColumn: "Id",
                keyValue: 11,
                column: "URL",
                value: "/Award");
        }
    }
}
