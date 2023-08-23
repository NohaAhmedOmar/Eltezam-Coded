using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElTezam_Coded_WebApp.Migrations
{
    public partial class EditDatetimeColsJobTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_CodeCategory",
                table: "Codes");

            migrationBuilder.DropForeignKey(
                name: "FK_CodesTemp_CodeCategory_CategoryId",
                table: "CodesTemp");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Codes",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "EmployeeVacations");

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
                name: "EnumId",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "EnumId1",
                table: "EmployeePayments");

            migrationBuilder.AlterColumn<string>(
                name: "Table",
                table: "RequestIdentities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GovernorateName",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GovernorateCode",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LocationCodes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "VacantDate",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VacationCode",
                table: "EmployeeVacations",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "EmployeeVacations",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "EmployeeVacations",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "DecisionDate",
                table: "EmployeeVacations",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationCodeId",
                table: "EmployeeVacations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionCode",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TerminationReasonCode",
                table: "Employees",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "TerminationDate",
                table: "Employees",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "SubAgencyID",
                table: "Employees",
                type: "int",
                nullable: true,
                defaultValueSql: "((2122))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceResponseNumber",
                table: "Employees",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ReligionCode",
                table: "Employees",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatusCode",
                table: "Employees",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Employees",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "HealthstatusCode",
                table: "Employees",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GenderCode",
                table: "Employees",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeCode",
                table: "Employees",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QualificationCode",
                table: "EmployeeQualifications",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "EmployeeQualifications",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MajorCode",
                table: "EmployeeQualifications",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GraduationDate",
                table: "EmployeeQualifications",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorCodeId",
                table: "EmployeeQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualificationCodeId",
                table: "EmployeeQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RankCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PaidDate",
                table: "EmployeePayments",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ElementCode",
                table: "EmployeePayments",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ConsolidationSetCode",
                table: "EmployeePayments",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ElementCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionStartDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionEndDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StepDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RankCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdateDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "JobClassCode",
                table: "EmployeeJobs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "GradeDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DecisionDate",
                table: "EmployeeJobs",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "EmployeeAppraisalInfo",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "EmployeeAppraisalInfo",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CodesTemp",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CodesTemp",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Codes",
                table: "Codes",
                columns: new[] { "Id", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacations_VacationCodeId_VacationCode",
                table: "EmployeeVacations",
                columns: new[] { "VacationCodeId", "VacationCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BloodType_BloodTypeCode",
                table: "Employees",
                columns: new[] { "BloodType", "BloodTypeCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender_GenderCode",
                table: "Employees",
                columns: new[] { "Gender", "GenderCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Healthstatus_HealthstatusCode",
                table: "Employees",
                columns: new[] { "Healthstatus", "HealthstatusCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MaritalStatus_MaritalStatusCode",
                table: "Employees",
                columns: new[] { "MaritalStatus", "MaritalStatusCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Religion_ReligionCode",
                table: "Employees",
                columns: new[] { "Religion", "ReligionCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_MajorCodeId_MajorCode",
                table: "EmployeeQualifications",
                columns: new[] { "MajorCodeId", "MajorCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_QualificationCodeId_QualificationCode",
                table: "EmployeeQualifications",
                columns: new[] { "QualificationCodeId", "QualificationCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ConsolidationSetID_ConsolidationSetCode",
                table: "EmployeePayments",
                columns: new[] { "ConsolidationSetID", "ConsolidationSetCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ElementCodeId_ElementCode",
                table: "EmployeePayments",
                columns: new[] { "ElementCodeId", "ElementCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EmploymentTypeCodeId_EmploymentTypeCode",
                table: "EmployeePayments",
                columns: new[] { "EmploymentTypeCodeId", "EmploymentTypeCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_RankCodeId_RankCode",
                table: "EmployeePayments",
                columns: new[] { "RankCodeId", "RankCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmploymentTypeCodeId_EmploymentTypeCode",
                table: "EmployeeJobs",
                columns: new[] { "EmploymentTypeCodeId", "EmploymentTypeCode" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_RankCodeId_RankCode",
                table: "EmployeeJobs",
                columns: new[] { "RankCodeId", "RankCode" });

            migrationBuilder.AddForeignKey(
                name: "FK__Codes__CategoryI__6E01572D",
                table: "Codes",
                column: "CategoryId",
                principalTable: "CodeCategory",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK__CodesTemp__Categ__10566F31",
                table: "CodesTemp",
                column: "CategoryId",
                principalTable: "CodeCategory",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK__EmployeeJobs__70A8B9AE",
                table: "EmployeeJobs",
                columns: new[] { "EmploymentTypeCodeId", "EmploymentTypeCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK__EmployeeJobs__719CDDE7",
                table: "EmployeeJobs",
                columns: new[] { "RankCodeId", "RankCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK__EmployeePayments__690797E6",
                table: "EmployeePayments",
                columns: new[] { "EmploymentTypeCodeId", "EmploymentTypeCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK__EmployeePayments__69FBBC1F",
                table: "EmployeePayments",
                columns: new[] { "RankCodeId", "RankCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Codes",
                table: "EmployeePayments",
                columns: new[] { "ConsolidationSetID", "ConsolidationSetCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Codes1",
                table: "EmployeePayments",
                columns: new[] { "ElementCodeId", "ElementCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeQualifications_Codes",
                table: "EmployeeQualifications",
                columns: new[] { "QualificationCodeId", "QualificationCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeQualifications_Codes1",
                table: "EmployeeQualifications",
                columns: new[] { "MajorCodeId", "MajorCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Codes",
                table: "Employees",
                columns: new[] { "Gender", "GenderCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Codes1",
                table: "Employees",
                columns: new[] { "Religion", "ReligionCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Codes2",
                table: "Employees",
                columns: new[] { "BloodType", "BloodTypeCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Codes3",
                table: "Employees",
                columns: new[] { "MaritalStatus", "MaritalStatusCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Codes4",
                table: "Employees",
                columns: new[] { "Healthstatus", "HealthstatusCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVacations_Codes",
                table: "EmployeeVacations",
                columns: new[] { "VacationCodeId", "VacationCode" },
                principalTable: "Codes",
                principalColumns: new[] { "Id", "Code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Codes__CategoryI__6E01572D",
                table: "Codes");

            migrationBuilder.DropForeignKey(
                name: "FK__CodesTemp__Categ__10566F31",
                table: "CodesTemp");

            migrationBuilder.DropForeignKey(
                name: "FK__EmployeeJobs__70A8B9AE",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK__EmployeeJobs__719CDDE7",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK__EmployeePayments__690797E6",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK__EmployeePayments__69FBBC1F",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayments_Codes1",
                table: "EmployeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Codes",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeQualifications_Codes1",
                table: "EmployeeQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Codes",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Codes1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Codes2",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Codes3",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Codes4",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVacations_Codes",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeVacations_VacationCodeId_VacationCode",
                table: "EmployeeVacations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BloodType_BloodTypeCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender_GenderCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Healthstatus_HealthstatusCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MaritalStatus_MaritalStatusCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Religion_ReligionCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_MajorCodeId_MajorCode",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeQualifications_QualificationCodeId_QualificationCode",
                table: "EmployeeQualifications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ConsolidationSetID_ConsolidationSetCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_ElementCodeId_ElementCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_EmploymentTypeCodeId_EmploymentTypeCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayments_RankCodeId_RankCode",
                table: "EmployeePayments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_EmploymentTypeCodeId_EmploymentTypeCode",
                table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_RankCodeId_RankCode",
                table: "EmployeeJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Codes",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "VacationCodeId",
                table: "EmployeeVacations");

            migrationBuilder.DropColumn(
                name: "MajorCodeId",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "QualificationCodeId",
                table: "EmployeeQualifications");

            migrationBuilder.DropColumn(
                name: "ConsolidationSetCode",
                table: "EmployeePayments");

            migrationBuilder.DropColumn(
                name: "ElementCodeId",
                table: "EmployeePayments");

            migrationBuilder.AlterColumn<string>(
                name: "Table",
                table: "RequestIdentities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GovernorateName",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GovernorateCode",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LocationCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VacantDate",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VacationCode",
                table: "EmployeeVacations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeVacations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeVacations",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DecisionDate",
                table: "EmployeeVacations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "EmployeeVacations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TerminationReasonCode",
                table: "Employees",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TerminationDate",
                table: "Employees",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubAgencyID",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((2122))");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceResponseNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReligionCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatusCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "LastNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HealthstatusCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "GenderCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstNameEn",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodTypeCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "QualificationCode",
                table: "EmployeeQualifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "EmployeeQualifications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorCode",
                table: "EmployeeQualifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationDate",
                table: "EmployeeQualifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "RankCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaidDate",
                table: "EmployeePayments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ElementCode",
                table: "EmployeePayments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

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
                name: "EnumId",
                table: "EmployeePayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnumId1",
                table: "EmployeePayments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionStartDate",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionEndDate",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StepDate",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RankCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "EmployeeJobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "JobClassCode",
                table: "EmployeeJobs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GradeDate",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentTypeCodeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DecisionDate",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeAppraisalInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeAppraisalInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CodesTemp",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CodesTemp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Codes",
                table: "Codes",
                column: "Code");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_CodeCategory",
                table: "Codes",
                column: "CategoryId",
                principalTable: "CodeCategory",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodesTemp_CodeCategory_CategoryId",
                table: "CodesTemp",
                column: "CategoryId",
                principalTable: "CodeCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Codes_ConsolidationSetCode1",
                table: "EmployeePayments",
                column: "ConsolidationSetCode1",
                principalTable: "Codes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Codes_ElementCodeNavigationCode1",
                table: "EmployeePayments",
                column: "ElementCodeNavigationCode1",
                principalTable: "Codes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Enums_EnumId",
                table: "EmployeePayments",
                column: "EnumId",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayments_Enums_EnumId1",
                table: "EmployeePayments",
                column: "EnumId1",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeQualifications_Enums_EnumId",
                table: "EmployeeQualifications",
                column: "EnumId",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeQualifications_Enums_EnumId1",
                table: "EmployeeQualifications",
                column: "EnumId1",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enums_EnumId",
                table: "Employees",
                column: "EnumId",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enums_EnumId1",
                table: "Employees",
                column: "EnumId1",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enums_EnumId2",
                table: "Employees",
                column: "EnumId2",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enums_EnumId3",
                table: "Employees",
                column: "EnumId3",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enums_EnumId4",
                table: "Employees",
                column: "EnumId4",
                principalTable: "Enums",
                principalColumn: "EnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVacations_Enums_EnumId",
                table: "EmployeeVacations",
                column: "EnumId",
                principalTable: "Enums",
                principalColumn: "EnumId");
        }
    }
}
