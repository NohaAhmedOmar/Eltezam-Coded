using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElTezam_Coded_WebApp.Migrations
{
    public partial class RequestIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Jobs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaNumber",
                table: "EmployeeVacations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalID",
                table: "EmployeeVacations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "EmployeeVacations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubAgencyID",
                table: "EmployeeVacations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalID",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubAgencyID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IqamaNumber",
                table: "EmployeeQualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalID",
                table: "EmployeeQualifications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "EmployeeQualifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubAgencyID",
                table: "EmployeeQualifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "EmployeePayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "EmployeeJobs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "EmployeeAppraisalInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "IqamaNumber",
                table: "EmployeeAppraisalInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestIdentityId",
                table: "EmployeeAppraisalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubAgencyID",
                table: "EmployeeAppraisalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestIdentities",
                columns: table => new
                {
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestIdentities", x => x.RequestNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_RequestIdentityId",
                table: "Jobs",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacations_RequestIdentityId",
                table: "EmployeeVacations",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RequestIdentityId",
                table: "Employees",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_RequestIdentityId",
                table: "EmployeeQualifications",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_RequestIdentityId",
                table: "EmployeePayments",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_RequestIdentityId",
                table: "EmployeeJobs",
                column: "RequestIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAppraisalInfo_RequestIdentityId",
                table: "EmployeeAppraisalInfo",
                column: "RequestIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAppraisalInfo_RequestIdentities_RequestIdentityId",
                table: "EmployeeAppraisalInfo",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobs_RequestIdentities_RequestIdentityId",
                table: "EmployeeJobs",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_RequestIdentities_RequestIdentityId",
                table: "EmployeePayments",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeQualifications_RequestIdentities_RequestIdentityId",
                table: "EmployeeQualifications",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RequestIdentities_RequestIdentityId",
                table: "Employees",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVacations_RequestIdentities_RequestIdentityId",
                table: "EmployeeVacations",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_RequestIdentities_RequestIdentityId",
                table: "Jobs",
                column: "RequestIdentityId",
                principalTable: "RequestIdentities",
                principalColumn: "RequestNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppraisalInfo_RequestIdentities_RequestIdentityId",
                table: "EmployeeAppraisalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobs_RequestIdentities_RequestIdentityId",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_RequestIdentities_RequestIdentityId",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_RequestIdentities_RequestIdentityId",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RequestIdentities_RequestIdentityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacations_RequestIdentities_RequestIdentityId",
                table: "EmployeeVacations");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_RequestIdentities_RequestIdentityId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "RequestIdentities");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_RequestIdentityId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeVacations_RequestIdentityId",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RequestIdentityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_RequestIdentityId",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_RequestIdentityId",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_RequestIdentityId",
                table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAppraisalInfo_RequestIdentityId",
                table: "EmployeeAppraisalInfo");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IqamaNumber",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "SubAgencyID",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "IqamaNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SubAgencyID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IqamaNumber",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "SubAgencyID",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "IqamaNumber",
                table: "EmployeeAppraisalInfo");

            migrationBuilder.DropColumn(
                name: "RequestIdentityId",
                table: "EmployeeAppraisalInfo");

            migrationBuilder.DropColumn(
                name: "SubAgencyID",
                table: "EmployeeAppraisalInfo");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Jobs",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);



            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "EmployeeAppraisalInfo",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);


        }
    }
}
