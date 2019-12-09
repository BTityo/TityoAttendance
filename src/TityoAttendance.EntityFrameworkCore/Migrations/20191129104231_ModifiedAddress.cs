using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class ModifiedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_County_CountyId",
                schema: "Address",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_County_Country_CountryId",
                schema: "Address",
                table: "County");

            migrationBuilder.DropIndex(
                name: "IX_County_CountryId",
                schema: "Address",
                table: "County");

            migrationBuilder.DropIndex(
                name: "IX_City_CountyId",
                schema: "Address",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "Address",
                table: "County");

            migrationBuilder.DropColumn(
                name: "CountyId",
                schema: "Address",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                schema: "Address",
                table: "Country",
                newName: "CountryCode");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "Address",
                table: "County",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountyCode",
                schema: "Address",
                table: "City",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "Address",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                schema: "Address",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "Address",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountyId",
                schema: "Address",
                table: "Address",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryId",
                schema: "Address",
                table: "Address",
                column: "CountryId",
                principalSchema: "Address",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_County_CountyId",
                schema: "Address",
                table: "Address",
                column: "CountyId",
                principalSchema: "Address",
                principalTable: "County",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryId",
                schema: "Address",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_County_CountyId",
                schema: "Address",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountryId",
                schema: "Address",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountyId",
                schema: "Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "Address",
                table: "County");

            migrationBuilder.DropColumn(
                name: "CountyCode",
                schema: "Address",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountyId",
                schema: "Address",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "Address",
                table: "Country",
                newName: "CityCode");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "Address",
                table: "County",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                schema: "Address",
                table: "City",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_County_CountryId",
                schema: "Address",
                table: "County",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountyId",
                schema: "Address",
                table: "City",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_County_CountyId",
                schema: "Address",
                table: "City",
                column: "CountyId",
                principalSchema: "Address",
                principalTable: "County",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_County_Country_CountryId",
                schema: "Address",
                table: "County",
                column: "CountryId",
                principalSchema: "Address",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
