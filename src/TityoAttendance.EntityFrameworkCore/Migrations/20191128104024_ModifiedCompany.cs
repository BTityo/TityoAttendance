using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class ModifiedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Company",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                schema: "Company",
                table: "Company",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Attendance",
                table: "Attendance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                schema: "Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Attendance",
                table: "Attendance");
        }
    }
}
