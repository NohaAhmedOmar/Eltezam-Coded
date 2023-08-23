using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElTezam_Coded_WebApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJob_Codes",
                table: "EmployeeJobs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeJob_Codes1",
            //    table: "EmployeeJobs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeJob_Codes2",
            //    table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Enums",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Enums1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Enums",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Enums1",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums2",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums3",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums4",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacations_Enums",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeVacations_VacationCode",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BloodType",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Healthstatus",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MaritalStatus",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Religion",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_MajorCode",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_QualificationCode",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ConsolidationSetID",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ElementCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_EmploymentTypeCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_RankCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_EmploymentTypeCode",
                table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_JobNameCode",
                table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_RankCode",
                table: "EmployeeJobs");

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "EmployeeVacations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodTypeCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId1",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId2",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId3",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId4",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HealthstatusCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatusCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReligionCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceResponseNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "EmployeeQualifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId1",
                table: "EmployeeQualifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsolidationSetCode1",
                table: "EmployeePayments",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElementCodeNavigationCode1",
                table: "EmployeePayments",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "EmployeePayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId1",
                table: "EmployeePayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CodesTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodesTemp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodesTemp_CodeCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CodeCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacations_EnumId",
                table: "EmployeeVacations",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnumId",
                table: "Employees",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnumId1",
                table: "Employees",
                column: "EnumId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnumId2",
                table: "Employees",
                column: "EnumId2");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnumId3",
                table: "Employees",
                column: "EnumId3");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnumId4",
                table: "Employees",
                column: "EnumId4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_EnumId",
                table: "EmployeeQualifications",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_EnumId1",
                table: "EmployeeQualifications",
                column: "EnumId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ConsolidationSetCode1",
                table: "EmployeePayments",
                column: "ConsolidationSetCode1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ElementCodeNavigationCode1",
                table: "EmployeePayments",
                column: "ElementCodeNavigationCode1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EnumId",
                table: "EmployeePayments",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EnumId1",
                table: "EmployeePayments",
                column: "EnumId1");

            migrationBuilder.CreateIndex(
                name: "IX_CodesTemp_CategoryId",
                table: "CodesTemp",
                column: "CategoryId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Codes_ConsolidationSetCode1",
            //    table: "EmployeePayments",
            //    column: "ConsolidationSetCode1",
            //    principalTable: "Codes",
            //    principalColumn: "Code",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Codes_ElementCodeNavigationCode1",
            //    table: "EmployeePayments",
            //    column: "ElementCodeNavigationCode1",
            //    principalTable: "Codes",
            //    principalColumn: "Code",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Enums_EnumId",
            //    table: "EmployeePayments",
            //    column: "EnumId",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Enums_EnumId1",
            //    table: "EmployeePayments",
            //    column: "EnumId1",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeQualifications_Enums_EnumId",
            //    table: "EmployeeQualifications",
            //    column: "EnumId",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeQualifications_Enums_EnumId1",
            //    table: "EmployeeQualifications",
            //    column: "EnumId1",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums_EnumId",
            //    table: "Employees",
            //    column: "EnumId",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums_EnumId1",
            //    table: "Employees",
            //    column: "EnumId1",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums_EnumId2",
            //    table: "Employees",
            //    column: "EnumId2",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums_EnumId3",
            //    table: "Employees",
            //    column: "EnumId3",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums_EnumId4",
            //    table: "Employees",
            //    column: "EnumId4",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeVacations_Enums_EnumId",
            //    table: "EmployeeVacations",
            //    column: "EnumId",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes_ConsolidationSetCode1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes_ElementCodeNavigationCode1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Enums_EnumId",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Enums_EnumId1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Enums_EnumId",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Enums_EnumId1",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums_EnumId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums_EnumId1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums_EnumId2",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums_EnumId3",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enums_EnumId4",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacations_Enums_EnumId",
                table: "EmployeeVacations");

            migrationBuilder.DropTable(
                name: "CodesTemp");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeVacations_EnumId",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnumId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnumId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnumId2",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnumId3",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnumId4",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_EnumId",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_EnumId1",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ConsolidationSetCode1",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ElementCodeNavigationCode1",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_EnumId",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_EnumId1",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "BloodTypeCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId3",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId4",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GenderCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HealthstatusCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatusCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReligionCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ServiceResponseNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "EnumId1",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "ConsolidationSetCode1",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "ElementCodeNavigationCode1",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeCodeId",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EnumId1",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "RankCodeId",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeCodeId",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "RankCodeId",
                table: "EmployeeJobs");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacations_VacationCode",
                table: "EmployeeVacations",
                column: "VacationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BloodType",
                table: "Employees",
                column: "BloodType");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender",
                table: "Employees",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Healthstatus",
                table: "Employees",
                column: "Healthstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MaritalStatus",
                table: "Employees",
                column: "MaritalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Religion",
                table: "Employees",
                column: "Religion");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_MajorCode",
                table: "EmployeeQualifications",
                column: "MajorCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_QualificationCode",
                table: "EmployeeQualifications",
                column: "QualificationCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ConsolidationSetID",
                table: "EmployeePayments",
                column: "ConsolidationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ElementCode",
                table: "EmployeePayments",
                column: "ElementCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EmploymentTypeCode",
                table: "EmployeePayments",
                column: "EmploymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_RankCode",
                table: "EmployeePayments",
                column: "RankCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmploymentTypeCode",
                table: "EmployeeJobs",
                column: "EmploymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_JobNameCode",
                table: "EmployeeJobs",
                column: "JobNameCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_RankCode",
                table: "EmployeeJobs",
                column: "RankCode");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeJob_Codes",
            //    table: "EmployeeJobs",
            //    column: "JobNameCode",
            //    principalTable: "Codes",
            //    principalColumn: "Code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeJob_Codes1",
            //    table: "EmployeeJobs",
            //    column: "EmploymentTypeCode",
            //    principalTable: "Codes",
            //    principalColumn: "Code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeJob_Codes2",
            //    table: "EmployeeJobs",
            //    column: "RankCode",
            //    principalTable: "Codes",
            //    principalColumn: "Code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Codes",
            //    table: "EmployeePayments",
            //    column: "EmploymentTypeCode",
            //    principalTable: "Codes",
            //    principalColumn: "Code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Codes1",
            //    table: "EmployeePayments",
            //    column: "RankCode",
            //    principalTable: "Codes",
            //    principalColumn: "Code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Enums",
            //    table: "EmployeePayments",
            //    column: "ConsolidationSetID",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeePayments_Enums1",
            //    table: "EmployeePayments",
            //    column: "ElementCode",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeQualifications_Enums",
            //    table: "EmployeeQualifications",
            //    column: "QualificationCode",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeQualifications_Enums1",
            //    table: "EmployeeQualifications",
            //    column: "MajorCode",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums",
            //    table: "Employees",
            //    column: "Gender",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums1",
            //    table: "Employees",
            //    column: "Religion",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums2",
            //    table: "Employees",
            //    column: "BloodType",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums3",
            //    table: "Employees",
            //    column: "MaritalStatus",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_Enums4",
            //    table: "Employees",
            //    column: "Healthstatus",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeVacations_Enums",
            //    table: "EmployeeVacations",
            //    column: "VacationCode",
            //    principalTable: "Enums",
            //    principalColumn: "EnumId");
        }
    }
}
