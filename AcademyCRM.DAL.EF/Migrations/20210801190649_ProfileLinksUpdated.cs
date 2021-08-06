using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyCRM.DAL.EF.Migrations
{
    public partial class ProfileLinksUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LinkToProfile",
                value: "https://www.linkedin.com/feed/");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LinkToProfile",
                value: "https://www.linkedin.com/feed/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LinkToProfile",
                value: "linkedin212");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LinkToProfile",
                value: "linkedin212");
        }
    }
}
