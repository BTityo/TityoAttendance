using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class AttendanceCompanyCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Attendance");

            migrationBuilder.EnsureSchema(
                name: "Company");

            migrationBuilder.EnsureSchema(
                name: "Salary");

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualDay = table.Column<DateTime>(nullable: false),
                    From = table.Column<TimeSpan>(nullable: false),
                    To = table.Column<TimeSpan>(nullable: false),
                    WorkedHours = table.Column<byte>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Address",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanyMap",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanyMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompanyMap_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompanyMap_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                schema: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllWorkedHours = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    AllPaidHours = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Income = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    HourlyWage = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    UserCompanyMapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_UserCompanyMap_UserCompanyMapId",
                        column: x => x.UserCompanyMapId,
                        principalSchema: "Company",
                        principalTable: "UserCompanyMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_UserId",
                schema: "Attendance",
                table: "Attendance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_AddressId",
                schema: "Company",
                table: "Company",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyMap_CompanyId",
                schema: "Company",
                table: "UserCompanyMap",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyMap_UserId",
                schema: "Company",
                table: "UserCompanyMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_UserCompanyMapId",
                schema: "Salary",
                table: "Salary",
                column: "UserCompanyMapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "Attendance");

            migrationBuilder.DropTable(
                name: "Salary",
                schema: "Salary");

            migrationBuilder.DropTable(
                name: "UserCompanyMap",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Company");
        }
    }
}
