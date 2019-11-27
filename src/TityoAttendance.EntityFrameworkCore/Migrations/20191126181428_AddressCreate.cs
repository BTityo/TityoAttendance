using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class AddressCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "County",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    CountyCode = table.Column<string>(maxLength: 2, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Address",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NatureOfPublicPlace",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureOfPublicPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    ZipCode = table.Column<short>(nullable: false),
                    CountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_County_CountyId",
                        column: x => x.CountyId,
                        principalSchema: "Address",
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<byte>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    NatureOfPublicPlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Address",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_NatureOfPublicPlace_NatureOfPublicPlaceId",
                        column: x => x.NatureOfPublicPlaceId,
                        principalSchema: "Address",
                        principalTable: "NatureOfPublicPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                schema: "Address",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_NatureOfPublicPlaceId",
                schema: "Address",
                table: "Address",
                column: "NatureOfPublicPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountyId",
                schema: "Address",
                table: "City",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_County_CountryId",
                schema: "Address",
                table: "County",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "NatureOfPublicPlace",
                schema: "Address");

            migrationBuilder.DropTable(
                name: "County",
                schema: "Address");
        }
    }
}
