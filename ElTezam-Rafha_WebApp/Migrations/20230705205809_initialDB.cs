using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElTezam_Coded_WebApp.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "EnumsCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumsCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernorateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.GovernorateId);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NationalityDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Codes_CodeCategory",
                        column: x => x.CategoryId,
                        principalTable: "CodeCategory",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Enums",
                columns: table => new
                {
                    EnumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnumValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enums", x => x.EnumId);
                    table.ForeignKey(
                        name: "FK_Enums_EnumsCategory",
                        column: x => x.CategoryId,
                        principalTable: "EnumsCategory",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Governorates",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "GovernorateId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThirdNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThirdNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NationalityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Healthstatus = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    JobNumber = table.Column<int>(type: "int", nullable: false),
                    JobClassCode = table.Column<int>(type: "int", nullable: false),
                    JobClassDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobCatChain = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    JobNameCode = table.Column<int>(type: "int", nullable: true),
                    JobNameDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmploymentTypeCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmploymentTypeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RankCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    StepID = table.Column<int>(type: "int", nullable: false),
                    StepDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FirstGradeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActualJobNameCode = table.Column<int>(type: "int", nullable: true),
                    ActualJobNameDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    JobOrganizationID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    JobOrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    ActualOrganizationID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ActualOrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NextPromotionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    GovernmentHireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LocationCode = table.Column<int>(type: "int", nullable: false),
                    MinistryHireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RemainingAnnualBalance = table.Column<double>(type: "float", nullable: true),
                    RemainingBusinessBalance = table.Column<double>(type: "float", nullable: true),
                    TransactionCode = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TerminationReasonCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Enums",
                        column: x => x.Gender,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_Employees_Enums1",
                        column: x => x.Religion,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_Employees_Enums2",
                        column: x => x.BloodType,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_Employees_Enums3",
                        column: x => x.MaritalStatus,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_Employees_Enums4",
                        column: x => x.Healthstatus,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                });

            migrationBuilder.CreateTable(
                name: "SubCities",
                columns: table => new
                {
                    SubCityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCities", x => x.SubCityId);
                    table.ForeignKey(
                        name: "FK_SubCities_Cities",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAppraisalInfo",
                columns: table => new
                {
                    AppraisalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AppraisalTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RatingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAppraisalInfo", x => x.AppraisalID);
                    table.ForeignKey(
                        name: "FK_EmployeeAppraisalInfo_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobs",
                columns: table => new
                {
                    EmployeeJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubAgencyID = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IqamaNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobNumber = table.Column<int>(type: "int", nullable: false),
                    JobClassCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    JobClassDescription = table.Column<string>(type: "text", nullable: true),
                    JobCatChain = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    JobNameCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    JobNameDescription = table.Column<string>(type: "text", nullable: true),
                    EmploymentTypeCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EmploymentTypeDescription = table.Column<string>(type: "text", nullable: true),
                    RankCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DescriptionType = table.Column<string>(type: "text", nullable: true),
                    StepID = table.Column<int>(type: "int", nullable: true),
                    StepDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BasicSalary = table.Column<double>(type: "float", nullable: true),
                    DecisionNumber = table.Column<int>(type: "int", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    GradeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDescription = table.Column<string>(type: "text", nullable: true),
                    TransactionStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobs", x => x.EmployeeJobId);
                    //table.ForeignKey(
                    //    name: "FK_EmployeeJob_Codes",
                    //    column: x => x.JobNameCode,
                    //    principalTable: "Codes",
                    //    principalColumn: "Code");
                    //table.ForeignKey(
                    //    name: "FK_EmployeeJob_Codes1",
                    //    column: x => x.EmploymentTypeCode,
                    //    principalTable: "Codes",
                    //    principalColumn: "Code");
                    //table.ForeignKey(
                    //    name: "FK_EmployeeJob_Codes2",
                    //    column: x => x.RankCode,
                    //    principalTable: "Codes",
                    //    principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_EmployeeJob_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayments",
                columns: table => new
                {
                    EmployeePayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubAgencyID = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IqamaNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmploymentTypeCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RankCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StepID = table.Column<int>(type: "int", nullable: true),
                    ConsolidationSetID = table.Column<int>(type: "int", nullable: false),
                    ConsolidationSetDescription = table.Column<string>(type: "text", nullable: true),
                    ElementCode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ElementClassification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NetPay = table.Column<double>(type: "float", nullable: false),
                    HijriMonth = table.Column<int>(type: "int", nullable: false),
                    HijriYear = table.Column<int>(type: "int", nullable: false),
                    GregorianMonth = table.Column<int>(type: "int", nullable: false),
                    GregorianYear = table.Column<int>(type: "int", nullable: false),
                    PaidDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayments", x => x.EmployeePayId);
                    table.ForeignKey(
                        name: "FK_EmployeePayments_Codes",
                        column: x => x.EmploymentTypeCode,
                        principalTable: "Codes",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_EmployeePayments_Codes1",
                        column: x => x.RankCode,
                        principalTable: "Codes",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_EmployeePayments_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_EmployeePayments_Enums",
                        column: x => x.ConsolidationSetID,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_EmployeePayments_Enums1",
                        column: x => x.ElementCode,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeQualifications",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationCode = table.Column<int>(type: "int", nullable: false),
                    MajorCode = table.Column<int>(type: "int", nullable: false),
                    UniversityCode = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    ScoreOutOf = table.Column<double>(type: "float", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    QualificationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeQualifications", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Enums",
                        column: x => x.QualificationCode,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Enums1",
                        column: x => x.MajorCode,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Universities",
                        column: x => x.UniversityCode,
                        principalTable: "Universities",
                        principalColumn: "UniversityId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    VacationCode = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DecisionNumber = table.Column<int>(type: "int", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmpoyeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_EmployeeVacations_Employees",
                        column: x => x.EmpoyeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_EmployeeVacations_Enums",
                        column: x => x.VacationCode,
                        principalTable: "Enums",
                        principalColumn: "EnumId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernorateId",
                table: "Cities",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_CategoryId",
                table: "Codes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAppraisalInfo_EmployeeId",
                table: "EmployeeAppraisalInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmployeeId",
                table: "EmployeeJobs",
                column: "EmployeeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ConsolidationSetID",
                table: "EmployeePayments",
                column: "ConsolidationSetID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_ElementCode",
                table: "EmployeePayments",
                column: "ElementCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EmployeeId",
                table: "EmployeePayments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_EmploymentTypeCode",
                table: "EmployeePayments",
                column: "EmploymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayments_RankCode",
                table: "EmployeePayments",
                column: "RankCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_EmployeeId",
                table: "EmployeeQualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_MajorCode",
                table: "EmployeeQualifications",
                column: "MajorCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_QualificationCode",
                table: "EmployeeQualifications",
                column: "QualificationCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_UniversityCode",
                table: "EmployeeQualifications",
                column: "UniversityCode");

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
                name: "IX_EmployeeVacations_EmpoyeeId",
                table: "EmployeeVacations",
                column: "EmpoyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacations_VacationCode",
                table: "EmployeeVacations",
                column: "VacationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enums_CategoryId",
                table: "Enums",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCities_CityId",
                table: "SubCities",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAppraisalInfo");

            migrationBuilder.DropTable(
                name: "EmployeeJobs");

            migrationBuilder.DropTable(
                name: "EmployeePayments");

            migrationBuilder.DropTable(
                name: "EmployeeQualifications");

            migrationBuilder.DropTable(
                name: "EmployeeVacations");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "SubCities");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CodeCategory");

            migrationBuilder.DropTable(
                name: "Enums");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropTable(
                name: "EnumsCategory");
        }
    }
}
