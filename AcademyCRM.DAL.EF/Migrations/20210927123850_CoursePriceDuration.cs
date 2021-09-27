using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyCRM.DAL.EF.Migrations
{
    public partial class CoursePriceDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationWeeks",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DurationWeeks", "Price" },
                values: new object[] { 8, 1250.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DurationWeeks", "Price" },
                values: new object[] { 7, 1550.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DurationWeeks", "Level", "Price" },
                values: new object[] { 16, 1, 1350.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DurationWeeks", "Level", "Price" },
                values: new object[] { 20, 1, 1850.0 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationWeeks", "Level", "Price", "Program", "Title", "TopicId" },
                values: new object[] { 15, "Design Patterns for Software development", 18, 2, 2850.0, "1. Decorator, 2. Bridge", "Design Patterns", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "DurationWeeks",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");
        }
    }
}
