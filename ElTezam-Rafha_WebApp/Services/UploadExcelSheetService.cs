using ElTezam_Coded_WebApp.DomainModels;
using Eltezam_Coded.DTOs;
using System.Data;
using System.Data.OleDb;
using System.Net.Http.Headers;
using static Eltezam_Coded.Enums.AllEnums;
using Bytescout.Spreadsheet;
using System.Linq;
using System.Reflection;
using System.Drawing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ElTezam_Coded_WebApp.Services
{
    public interface IUploadExcelSheetService
    {
        public Task<ResponseModel> PostExcelSheet(IFormFile FormFile, Table table);
    }
    public class UploadExcelSheetService : IUploadExcelSheetService
    {
        private readonly CodedContext _context;
        private readonly IConfiguration configuration;
        public UploadExcelSheetService(CodedContext _context, IConfiguration configuration) { this._context = _context; this.configuration = configuration; }




        public async Task<ResponseModel> PostExcelSheet(IFormFile FormFile, Table table)
        {
            try
            {
                //get file name
                var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                string[] tokens = filename.Split('.');
                string format = tokens[tokens.Length - 1].ToLower();
                if (format != "xlsx".ToLower() && format != "xls".ToLower())
                {
                    // ViewBag.TypeError = "Invalid File Format";
                    return new ResponseModel { IsSuccess = false, StatusCode = 400 };
                }
                else
                {
                    //get path
                    var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                    if (!Directory.Exists(MainPath))
                    {
                        Directory.CreateDirectory(MainPath);
                    }

                    //get file path 
                    var filePath = Path.Combine(MainPath, FormFile.FileName);
                    using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }

                    string extension = Path.GetExtension(filename);


                    string conString = string.Empty;

                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }
                    System.Data.DataTable dt = new System.Data.DataTable();
                    conString = string.Format(conString, filePath);


                    Spreadsheet document = new Spreadsheet();
                    //document.LoadFromFile(@"C:\Users\Intalio\Downloads\submitEmployeeInfo.xlsx");
                    //document.LoadFromFile(@"E:\Noha\Projects\ForNuhaEltezam\MCS-Eltezam Data Dictionary v3.25.xlsx");
                    Worksheet worksheet = document.Workbook.Worksheets.ByName("submitEmployeeInfo");
                    List<string> workSheetNames = new List<string>();

                    for (int i = 1; i < document.Workbook.Worksheets.Count; i++)
                    {
                        workSheetNames.Add(document.Workbook.Worksheets[i].Name);
                    }

                    //for (int i = 0; i < 2; i++)
                    //{
                    //    for (int j = 0; j < 3; j++)
                    //    {
                    //        //Console.WriteLine(worksheet.Cell(i, j));
                    //    }
                    //}
                    //document.Close();
                    //Console.ReadKey();
                    //Microsoft.Office.Interop.Excel.Application application =
                    //    new Microsoft.Office.Interop.Excel.Application();


                    //Microsoft.Office.Interop.Excel.Workbook workBook = application.Workbooks.Open(filePath);

                    //string workbookName = workBook.Name;
                    //int numberOfSheets = workBook.Sheets.Count;

                    //List<string> workSheetNames = new List<string>();
                    //for (int i = 1; i <= workBook.Sheets.Count; i++)
                    //{
                    //    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[i];
                    //    workSheetNames.Add(worksheet.Name);
                    //}

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                // string sheetName = "Sheet1";
                                connExcel.Close();

                                List<string> sheetNamesD = new List<string>
                                {
  //"JobClassCode",
  //"EmployeeStatusCode",
  //"JobNameCode",
  //"EmploymentTypeCode",
  //"RankCode",
                                };

                                //foreach (var sheet in workSheetNames)
                                //{
                                //    if (sheetNamesD.Contains(sheet))
                                //    { 

                                //    }
                                //}

                                //string SheetName = "EmployeeStatusCode";
                                ////Read Data from First Sheet.
                                //connExcel.Open();
                                //cmdExcel.CommandText = $"SELECT * From [{SheetName}$]";
                                //odaExcel.SelectCommand = cmdExcel;
                                //odaExcel.Fill(dt);
                                //_ = table switch
                                //{
                                //    Table.Employees => await BulkEmployees(dt),
                                //    Table.EmployeePayments => BulkEmployeePayments(dt),
                                //    Table.EmployeeAppraisalInfo => BulkEmployeeAppraisals(dt),
                                //    Table.EmployeeQualifications => BulkEmployeeQualifications(dt),
                                //    Table.EmployeeVacations => BulkEmployeeVacations(dt),
                                //    Table.EmployeeJobs => BulkEmloyeeHistoricalInfo(dt),
                                //    Table.Jobs => BulkJobs(dt),
                                //    Table.Codes => BulkCodes(dt),

                                //};
                                //foreach (var sheet in workSheetNames)
                                //{
                                //    if (sheetNamesD.Contains(sheet))
                                //    {
                                //        string SheetName = sheet;
                                //        //Read Data from First Sheet.
                                //        connExcel.Open();
                                //        cmdExcel.CommandText = $"SELECT * From [{SheetName}$]";
                                //        odaExcel.SelectCommand = cmdExcel;
                                //        odaExcel.Fill(dt);
                                //        _ = table switch
                                //        {
                                //            Table.Employees => await BulkEmployees(dt),
                                //            Table.EmployeePayments => BulkEmployeePayments(dt),
                                //            Table.EmployeeAppraisalInfo => BulkEmployeeAppraisals(dt),
                                //            Table.EmployeeQualifications => BulkEmployeeQualifications(dt),
                                //            Table.EmployeeVacations => BulkEmployeeVacations(dt),
                                //            Table.EmployeeJobs => BulkEmloyeeHistoricalInfo(dt),
                                //            Table.Jobs => BulkJobs(dt),
                                //            Table.Codes => BulkCodes(dt),

                                //        };
                                //    }
                                //    connExcel.Close();

                                //}


                                    string SheetName = "submitEmployeeHistoricalInfo";
                                    //Read Data from First Sheet.
                                    connExcel.Open();
                                    cmdExcel.CommandText = $"SELECT * From [{SheetName}$]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    _ = table switch
                                    {
                                        Table.Employees => await BulkEmployees(dt),
                                        Table.EmployeePayments => BulkEmployeePayments(dt),
                                        Table.EmployeeAppraisalInfo => BulkEmployeeAppraisals(dt),
                                        Table.EmployeeQualifications => BulkEmployeeQualifications(dt),
                                        Table.EmployeeVacations => BulkEmployeeVacations(dt),
                                        Table.EmployeeJobs => BulkEmloyeeHistoricalInfo(dt),
                                        Table.Jobs => BulkJobs(dt),
                                        Table.Codes => BulkCodes(dt),

                                    };

                                connExcel.Close();
                            }
                        }
                    }

                    return new ResponseModel { IsSuccess = true, StatusCode = 201 };
                }

            }
            catch (Exception e)
            {

                return new ResponseModel { IsSuccess = false, StatusCode = 500, Data = e };
            }

        }
        private async Task<bool> BulkEmployees(DataTable dt)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int JobNumber;
                    int.TryParse(dt.Rows[i]["JobNumber"].ToString(), out JobNumber);
                    int StepId;
                    int.TryParse(dt.Rows[i]["StepID"].ToString(), out StepId);
                    int BasicSalary;
                    int.TryParse(dt.Rows[i]["BasicSalary"].ToString(), out BasicSalary);

                    var employee = new Employee
                    {
                        FirstNameAr = dt.Rows[i]["FirstName"].ToString(),
                        SecondNameAr = dt.Rows[i]["SecondName"].ToString(),
                        ThirdNameAr = dt.Rows[i]["ThirdName"].ToString(),
                        LastNameAr = dt.Rows[i]["LastName"].ToString(),
                        BirthDate = dt.Rows[i]["BirthDate"].ToString(),
                        Gender = _context.Codes.Where(x => x.Value == dt.Rows[i]["Gender"].ToString()).Select(x => x.Id).SingleOrDefault(),
                        GenderCode = _context.Codes.Where(x => x.Value == dt.Rows[i]["Gender"].ToString()).Select(x => x.Code1).SingleOrDefault(),
                        NationalityCode = dt.Rows[i]["NationalityCode"].ToString(),
                        Religion = _context.Codes.Where(x => x.Value == dt.Rows[i]["Religion"].ToString()).Select(x => x.Id).SingleOrDefault(),
                        ReligionCode = _context.Codes.Where(x => x.Value == dt.Rows[i]["Religion"].ToString()).Select(x => x.Code1).SingleOrDefault(),
                        // BloodType = BloodType,
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        EmailAddress = dt.Rows[i]["EmailAddress"].ToString(),
                        MaritalStatus = _context.Codes.Where(x => x.Code1 == dt.Rows[i]["MaritalStatusType"].ToString()).Select(x => x.Id).SingleOrDefault(),
                        MaritalStatusCode = _context.Codes.Where(x => x.Code1 == dt.Rows[i]["MaritalStatusType"].ToString()).Select(x => x.Code1).SingleOrDefault(),
                        Healthstatus = _context.Codes.Where(x => x.Code1 == dt.Rows[i]["HealthstatusType"].ToString()).Select(x => x.Id).SingleOrDefault(),
                        HealthstatusCode = _context.Codes.Where(x => x.Code1 == dt.Rows[i]["HealthstatusType"].ToString()).Select(x => x.Code1).SingleOrDefault(),
                        EmployeeStatusCode = dt.Rows[i]["EmployeeStatusCode"].ToString(),
                        JobNumber = JobNumber,
                        JobClassCode = dt.Rows[i]["JobClassCode"].ToString(),
                        JobNameCode = dt.Rows[i]["JobNameCode"].ToString(),
                        EmploymentTypeCode = dt.Rows[i]["EmploymentTypeCode"].ToString(),
                        RankCode = dt.Rows[i]["RankCode"].ToString(),
                        NationalId = dt.Rows[i]["NationalId/Iqama"].ToString(),
                        StepId = StepId,
                        FirstGradeDate = dt.Rows[i]["FirstGradeDate"].ToString(),
                        JobOrganizationId = dt.Rows[i]["JobOrganizationID"].ToString(),
                        JobOrganizationName = dt.Rows[i]["JobOrganizationName"].ToString(),
                        BasicSalary = BasicSalary,
                        LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                        MinistryHireDate = dt.Rows[i]["MinistryHireDate"].ToString(),
                        IsActive = (dt.Rows[i]["IsActive"].ToString() == "YES" ? true : false),
                        LastUpdateDate = dt.Rows[i]["LastUpdateDate"].ToString(),
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private bool BulkEmployeePayments(DataTable dt)
        {
            try
            {
                List<EmployeePayment> employeePayments = new List<EmployeePayment>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int HijriMonth;
                    int.TryParse(dt.Rows[i]["HijriMonth"].ToString(), out HijriMonth);
                    int HijriYear;
                    int.TryParse(dt.Rows[i]["HijriYear"].ToString(), out HijriYear);
                    int GregorianMonth;
                    int.TryParse(dt.Rows[i]["GregorianMonth"].ToString(), out GregorianMonth);
                    int GregorianYear;
                    int.TryParse(dt.Rows[i]["GregorianYear"].ToString(), out GregorianYear);
                    int NetPay;
                    int.TryParse(dt.Rows[i]["NetPay"].ToString(), out NetPay);
                    int ConsolidationSetID;
                    int.TryParse(dt.Rows[i]["ConsolidationSetID"].ToString(), out ConsolidationSetID);
                    int StepId;
                    int.TryParse(dt.Rows[i]["StepID"].ToString(), out StepId);
                    int ElementCode;
                    int.TryParse(dt.Rows[i]["ElementCode"].ToString(), out ElementCode);
                    double Amount;
                    double.TryParse(dt.Rows[i]["Amount"].ToString(), out Amount);
                    var paiddate = dt.Rows[i]["PaidDate"].ToString();

                    string PersonIdentifier = dt.Rows[i]["PersonIdentifier"].ToString();
                    var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();

                    Code _employmentTypeCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["EmploymentTypeCode"].ToString() && a.CategoryId == 3).FirstOrDefault();
                    Code _rankCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["RankCode"].ToString() && a.CategoryId == 1).FirstOrDefault();
                    Code _consolidationSetCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["ConsolidationSetID"].ToString() && a.CategoryId == 13).FirstOrDefault();
                    Code _elementCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["ElementCode"].ToString() && a.CategoryId == 14).FirstOrDefault();

                    var employeePayment = new EmployeePayment
                    {
                        EmployeeId = emp.EmployeeId,
                        NationalId = dt.Rows[i]["PersonIdentifier"].ToString(),
                        EmployeeName = dt.Rows[i]["EmployeeName"].ToString(),
                        EmploymentTypeCode = _employmentTypeCode.Code1,
                        EmploymentTypeCodeId = _employmentTypeCode.Id,
                        RankCode = _rankCode.Code1,
                        RankCodeId = _rankCode.Id,
                        StepId = StepId,
                        HijriMonth = HijriMonth,
                        HijriYear = HijriYear,
                        GregorianMonth = GregorianMonth,
                        GregorianYear = GregorianYear,
                        PaidDate = paiddate,
                        NetPay = NetPay,
                        ConsolidationSetId = _consolidationSetCode.Id,
                        ConsolidationSetCode = _consolidationSetCode.Code1,
                        ElementCode = _elementCode.Code1,
                        ElementCodeId = _elementCode.Id,
                        Amount = Amount,
                        ElementClassification = dt.Rows[i]["ElementClassification"].ToString(),
                    };

                    employeePayments.Add(employeePayment);
                }
                _context.EmployeePayments.AddRange(employeePayments);
                int res = _context.SaveChanges();
                return res == employeePayments.Count;
            }
            catch (Exception ex)
            {
            }

            return true;
        }
        private bool BulkEmployeeAppraisals(DataTable dt)
        {
            try
            {
                List<EmployeeAppraisalInfo> employeeAppraisals = new List<EmployeeAppraisalInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PersonIdentifier = dt.Rows[i]["PersonIdentifier"].ToString();
                    var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();

                    var employeeAppraisal = new EmployeeAppraisalInfo
                    {
                        EmployeeId = emp.EmployeeId,
                        EndDate = dt.Rows[i]["StartDate"].ToString(),
                        StartDate = dt.Rows[i]["StartDate"].ToString(),
                        AppraisalTypeCode = dt.Rows[i]["AppraisalTypeCode"].ToString(),
                        TransactionType = dt.Rows[i]["TransactionType"].ToString(),
                        Result = dt.Rows[i]["Result"].ToString(),
                        RatingCode = dt.Rows[i]["RatingCode"].ToString(),
                        NationalId = dt.Rows[i]["PersonIdentifier"].ToString()
                    };

                    employeeAppraisals.Add(employeeAppraisal);
                }
                _context.EmployeeAppraisalInfos.AddRange(employeeAppraisals);
                int res = _context.SaveChanges();
                return res == employeeAppraisals.Count;
            }
            catch (Exception ex)
            {
            }

            return true;
        }
        private bool BulkEmployeeQualifications(DataTable dt)
        {
            try
            {
                List<EmployeeQualification> employeeQualifications = new List<EmployeeQualification>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PersonIdentifier = dt.Rows[i]["PersonIdentifier"].ToString();
                    var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();
                    if (emp is not null)
                    {
                        int UniversityCode;
                        int.TryParse(dt.Rows[i]["UniversityCode"].ToString(), out UniversityCode);
                        Code _qualificationCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["QualificationCode"].ToString() && a.CategoryId == 15).FirstOrDefault();
                        Code _majorCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["MajorCode"].ToString() && a.CategoryId == 16).FirstOrDefault();
                        var employeeQualification = new EmployeeQualification
                        {
                            EmployeeId = emp.EmployeeId,
                            UniversityCode = UniversityCode,
                            QualificationCode = dt.Rows[i]["QualificationCode"].ToString(),
                            QualificationCodeId = _qualificationCode.Id,
                            TransactionType = dt.Rows[i]["TransactionType"].ToString(),
                            QualificationStatus = dt.Rows[i]["QualificationStatus"].ToString(),
                            NationalId = dt.Rows[i]["PersonIdentifier"].ToString(),
                            MajorCode = dt.Rows[i]["MajorCode"].ToString(),
                            MajorCodeId = _majorCode.Id,
                            Grade = dt.Rows[i]["Grade"].ToString()
                        };
                        _context.EmployeeQualifications.Add(employeeQualification);
                        _context.SaveChanges();
                        employeeQualifications.Add(employeeQualification);
                    }
                }
                //_context.EmployeeQualifications.AddRange(employeeQualifications);
                //int res = _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return true;
        }
        private bool BulkEmployeeVacations(DataTable dt)
        {
            try
            {
                List<EmployeeVacation> employeeVacations = new List<EmployeeVacation>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PersonIdentifier = dt.Rows[i]["PersonIdentifier"].ToString();
                    var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();
                    if (emp is not null)
                    {
                        int VacationCode;
                        int.TryParse(dt.Rows[i]["VacationCode"].ToString(), out VacationCode);
                        int Period;
                        int.TryParse(dt.Rows[i]["Period"].ToString(), out Period);

                        Code _vacationCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["VacationCode"].ToString() && a.CategoryId == 12).FirstOrDefault();

                        var employeeVacation = new EmployeeVacation
                        {
                            EmpoyeeId = emp.EmployeeId,
                            VacationCode = _vacationCode.Code1,
                            VacationCodeId = _vacationCode.Id,
                            StartDate = dt.Rows[i]["StartDate"].ToString(),
                            EndDate = dt.Rows[i]["EndDate"].ToString(),
                            TransactionType = dt.Rows[i]["TransactionType"].ToString(),
                            Period = int.Parse(dt.Rows[i]["Period"].ToString()),
                            NationalId = dt.Rows[i]["PersonIdentifier"].ToString(),
                        };

                        employeeVacations.Add(employeeVacation);
                    }
                }
                _context.EmployeeVacations.AddRange(employeeVacations);
                int res = _context.SaveChanges();
                return res == employeeVacations.Count;
            }
            catch (Exception ex)
            {

            }

            return true;
        }
        private bool BulkEmloyeeHistoricalInfo(DataTable dt)
        {
            try
            {
                List<EmployeeHistoricalInfo> employeeHistoricalList = new List<EmployeeHistoricalInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PersonIdentifier = dt.Rows[i]["NationalId/Iqama"].ToString();
                    var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();
                    if (emp is not null)
                    {
                        Code _jobClassCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["JobClassCode"].ToString() && a.CategoryId == 7).FirstOrDefault();
                        Code _jobNameCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["JobNameCode"].ToString() && a.CategoryId == 4).FirstOrDefault();
                        Code _employmentTypeCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["EmploymentTypeCode"].ToString() && a.CategoryId == 3).FirstOrDefault();
                        Code _RankCode = _context.Codes.Where(a => a.Code1 == dt.Rows[i]["RankCode"].ToString() && a.CategoryId == 1).FirstOrDefault();

                        var employeeHistorical = new EmployeeHistoricalInfo
                        {
                            EmployeeId = emp.EmployeeId,
                            NationalId = emp.NationalId,
                            JobNumber = int.Parse(dt.Rows[i]["JobNumber"].ToString()),

                            JobClassCode = _jobClassCode.Code1,
                            JobClassCodeId = _jobClassCode.Id,
                            JobNameCode = _jobNameCode.Code1,
                            JobNameCodeId = _jobNameCode.Id,
                            EmploymentTypeCode = _employmentTypeCode.Code1,
                            EmploymentTypeCodeId = _employmentTypeCode.Id,
                            RankCode = _RankCode.Code1,
                            RankCodeId = _RankCode.Id,

                            StepId = !string.IsNullOrEmpty(dt.Rows[i]["StepId"].ToString()) ? int.Parse(dt.Rows[i]["StepId"].ToString()) : null,
                            LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                            TransactionCode = dt.Rows[i]["TransactionCode"].ToString(),
                            TransactionStartDate = dt.Rows[i]["TransactionStartDate"].ToString(),
                            LastUpdateDate = dt.Rows[i]["LastUpdateDate"].ToString(),
                        };
                        employeeHistoricalList.Add(employeeHistorical);
                    }
                }
                _context.EmployeeHistoricalInfos.AddRange(employeeHistoricalList);
                int res = _context.SaveChanges();
                return res == employeeHistoricalList.Count;
            }
            catch (Exception ex)
            {
            }

            return true;
        }
        private bool BulkJobs(DataTable dt)
        {
            try
            {
                List<Job> jobs = new List<Job>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["JobPositionCode"].ToString()))
                    {
                        string PersonIdentifier = dt.Rows[i]["PersonIdentifier"].ToString();
                        var emp = _context.Employees.Where(x => x.NationalId == PersonIdentifier).FirstOrDefault();

                        long EmployeeID = 0;
                        long.TryParse(dt.Rows[i]["EmployeeID"].ToString(), out EmployeeID);

                        int JobNumber;
                        int.TryParse(dt.Rows[i]["JobNumber"].ToString(), out JobNumber);
                        //int JobPositionCode;
                        //int.TryParse(dt.Rows[i]["JobPositionCode"].ToString(), out JobPositionCode);   
                        int JobOrganizationID;
                        int.TryParse(dt.Rows[i]["JobOrganizationID"].ToString(), out JobOrganizationID);

                        var job = new Job
                        {
                            EmployeeId = string.IsNullOrEmpty(PersonIdentifier) ? null : emp.EmployeeId,
                            NationalId = dt.Rows[i]["PersonIdentifier"].ToString(),
                            JobNumber = JobNumber,
                            JobClassCode = dt.Rows[i]["JobClassCode"].ToString(),
                            JobNameCode = dt.Rows[i]["JobNameCode"].ToString(),
                            JobPositionCode = dt.Rows[i]["JobPositionCode"].ToString(),
                            PositionOrganizationId = JobOrganizationID,
                            PositionOrganizationName = dt.Rows[i]["JobOrganizationName"].ToString(),
                            PositionStatus = dt.Rows[i]["PositionStatus"].ToString(),
                            EmploymentTypeCode = dt.Rows[i]["EmploymentTypeCode"].ToString(),
                            RankCode = dt.Rows[i]["RankCode"].ToString(),
                            LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                            JobTransactionCode = (!string.IsNullOrEmpty(dt.Rows[i]["JobTransactionCode"].ToString()) ? dt.Rows[i]["JobTransactionCode"].ToString() : null),
                            StartDate = dt.Rows[i]["StartDate"].ToString(),
                            LastUpdateDate = dt.Rows[i]["LastUpdateDate"].ToString(),
                            VacantDate = (!string.IsNullOrEmpty(dt.Rows[i]["VacantDate"].ToString()) ? dt.Rows[i]["VacantDate"].ToString() : null),
                            EndDate = (!string.IsNullOrEmpty(dt.Rows[i]["EndDate"].ToString()) ? dt.Rows[i]["EndDate"].ToString() : null),
                        };
                        jobs.Add(job);
                    }
                }
                _context.Jobs.AddRange(jobs);
                int res = _context.SaveChanges();
                return res == jobs.Count;
            }
            catch (Exception ex)
            {
            }

            return true;
        }
        private bool BulkCodes(DataTable dt)
        {
            List<Code> codes = new List<Code>();
            List<string> co = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (!string.IsNullOrEmpty(dt.Rows[i]["JobNameCode"].ToString()))
                {
                    int Category;
                    int.TryParse(dt.Rows[i]["Category"].ToString(), out Category);
                    var code = new Code
                    {
                        Code1 = dt.Rows[i]["JobNameCode"].ToString(),
                        Value = dt.Rows[i]["JobNameDescription"].ToString(),
                        CategoryId = Category


                    };
                    codes.Add(code
                    );
                    co.Add(dt.Rows[i]["JobNameCode"].ToString());
                }
            }
            _context.Codes.AddRange(codes);
            int res = _context.SaveChanges();
            return res == codes.Count;
        }
    }
}
