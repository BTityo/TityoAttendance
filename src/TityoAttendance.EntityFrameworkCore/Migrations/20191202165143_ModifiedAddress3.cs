using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class ModifiedAddress3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "Address",
                table: "Country",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "CountyCode",
                schema: "Address",
                table: "City",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "Address",
                table: "Country",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "CountyCode",
                schema: "Address",
                table: "City",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }
    }
}
