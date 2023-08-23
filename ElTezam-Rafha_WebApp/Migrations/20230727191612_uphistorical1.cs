using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElTezam_Coded_WebApp.Migrations
{
    public partial class uphistorical1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_EmployeeJobs_Codes_Code1",
              table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_Code1",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "Code1",
                table: "EmployeeJobs");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
