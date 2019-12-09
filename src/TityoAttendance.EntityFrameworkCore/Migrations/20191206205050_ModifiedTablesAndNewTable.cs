using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TityoAttendance.Migrations
{
    public partial class ModifiedTablesAndNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AbpUsers_UserId",
                schema: "Attendance",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_UserCompanyMap_UserCompanyMapId",
                schema: "Salary",
                table: "Salary");

            migrationBuilder.EnsureSchema(
                name: "Project");

            migrationBuilder.RenameColumn(
                name: "UserCompanyMapId",
                schema: "Salary",
                table: "Salary",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Salary_UserCompanyMapId",
                schema: "Salary",
                table: "Salary",
                newName: "IX_Salary_ProjectId");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Attendance",
                table: "Attendance",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Attendance",
                table: "Attendance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 8, nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ProjectId",
                schema: "Attendance",
                table: "Attendance",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                schema: "Project",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Project_ProjectId",
                schema: "Attendance",
                table: "Attendance",
                column: "ProjectId",
                principalSchema: "Project",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AbpUsers_UserId",
                schema: "Attendance",
                table: "Attendance",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Project_ProjectId",
                schema: "Salary",
                table: "Salary",
                column: "ProjectId",
                principalSchema: "Project",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Project_ProjectId",
                schema: "Attendance",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AbpUsers_UserId",
                schema: "Attendance",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Project_ProjectId",
                schema: "Salary",
                table: "Salary");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_ProjectId",
                schema: "Attendance",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Attendance",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                schema: "Salary",
                table: "Salary",
                newName: "UserCompanyMapId");

            migrationBuilder.RenameIndex(
                name: "IX_Salary_ProjectId",
                schema: "Salary",
                table: "Salary",
                newName: "IX_Salary_UserCompanyMapId");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Attendance",
                table: "Attendance",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AbpUsers_UserId",
                schema: "Attendance",
                table: "Attendance",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_UserCompanyMap_UserCompanyMapId",
                schema: "Salary",
                table: "Salary",
                column: "UserCompanyMapId",
                principalSchema: "Company",
                principalTable: "UserCompanyMap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
