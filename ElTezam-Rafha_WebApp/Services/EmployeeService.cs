using AutoMapper;
using ElTezam_Coded_WebApp.DomainModels;
using Eltezam_Coded.DTOs;
using Microsoft.EntityFrameworkCore;
using ElTezam_Coded_WebApp.DTOs;
using ElTezam_Coded_WebApp.DapperORM;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Drawing;
using System.Reflection;

namespace Eltezam_Coded.Services
{
    public interface IEmployeeService
    {
        Task<object> GetEmployees();
        Task<List<Employee>> GetEmployeesForSoap(List<long> Ids);
        Task<List<EmployeeAppraisalInfo>> GetAppraisalForSoap(List<long> Ids);
        Task<List<EmployeeJob>> GetHistoricalInfoForSoap(List<long> Ids);
        Task<List<Job>> GetJobInfoForSoap(List<long> Ids);
        Task<List<EmployeePayment>> GetPayslipInfoForSoap(List<long> Ids);
        Task<List<EmployeeQualification>> GetQualificationInfoForSoap(List<long> Ids);
        Task<List<EmployeeVacation>> GetVacationInfoForSoap(List<long> Ids);
        Task<ResponseModel> GetEmployeesView();
        Task<ResponseModel> GetEmployeesPaysView();
        Task<ResponseModel> GetEmployeesVacationsView();
        Task<ResponseModel> GetEmployeesAppraisalsView();
        Task<ResponseModel> GetEmployeesQualificationsView();
        Task<ResponseModel> GetEmployeeHistoricalView();
        Task<ResponseModel> GetJobView();
        Task<ResponseModel> SubmitEmployeeInfo(EmployeeDTO employeeDTO);
        Task<ResponseModel> SubmitEmployeeVacationInfo(EmployeeVacationDTO employeeVacationDTO);
        Task<ResponseModel> SubmitEmployeeVacationInfo(List<EmployeeVacationDTO> employeeVacationDTOs);
        Task<ResponseModel> SubmitEmployeeQualificationInfo(EmployeeQualificationDTO employeeQualificationDTO);
        Task<ResponseModel> SubmitEmployeeQualificationInfo(List<EmployeeQualificationDTO> employeeQualificationDTOs);
        Task<ResponseModel> SubmitEmployeePaysInfo(EmployeePaymentDTO employeePaymentDTO);
        Task<ResponseModel> SubmitEmployeeAppraisalInfo(EmployeeAppraisalInfoDTO employeeAppraisalInfoDTO);
        Task<ResponseModel> SubmitEmployeeHistoricalInfo(EmployeeJobDTO employeeJobDTO);
        Task<ResponseModel> SubmitJobInfo(JobDTO jobDTO);
        Task<ResponseModel> BulkDeleteEmployee(List<long> Ids);
        Task<ResponseModel> BulkDeleteEmployeeVacation(List<int> Ids);
        Task<ResponseModel> BulkDeleteEmployeeQualification(List<int> Ids);
        Task<ResponseModel> BulkDeleteEmployeePays(List<int> Ids);
        Task<ResponseModel> BulkDeleteEmployeeAppraisal(List<int> Ids);
        Task<ResponseModel> BulkDeleteEmployeeHistorical(List<int> Ids);
        Task<ResponseModel> BulkDeleteJob(List<int> Ids);
        Task<bool> SaveResponseNumberForEmployee(string NationalId, string ResponseNumber);
    }
    public class EmployeeService : IEmployeeService
    {
        private CodedContext context;
        private IMapper mapper;
        private ElTezam_Coded_WebApp.DapperORM.Dapper<Employee> employeeDapper;

        public EmployeeService(IMapper mapper, CodedContext context)
        {
            this.context = context;
            this.mapper = mapper;
            employeeDapper = Dapper<Employee>.GetInstance().Result;
        }

        public async Task<ResponseModel> BulkDeleteEmployee(List<long> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeVacations where EmpoyeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeJobs where EmployeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeAppraisalInfo where EmployeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeePayments where EmployeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeQualifications where EmployeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete Jobs where EmployeeId={Id} ");
                await context.Database.ExecuteSqlRawAsync($"Delete Employees where EmployeeId={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteEmployeeAppraisal(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeAppraisalInfo where AppraisalID={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteEmployeeHistorical(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeJobs where EmployeeJobId={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteEmployeePays(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeePayments where EmployeePayId={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteEmployeeQualification(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeQualifications where QualificationID={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteEmployeeVacation(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete EmployeeVacations where VacationId={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<ResponseModel> BulkDeleteJob(List<int> Ids)
        {
            foreach (var Id in Ids)
            {
                await context.Database.ExecuteSqlRawAsync($"Delete Jobs where JobPositionCode={Id} ");


            }
            return new ResponseModel { IsSuccess = true, StatusCode = 204, Data = Ids };
        }

        public async Task<List<EmployeeAppraisalInfo>> GetAppraisalForSoap(List<long> Ids)
        {
            List<EmployeeAppraisalInfo> EmployeeAppraisalInfo = new();
            foreach (var Id in Ids)
            {
                EmployeeAppraisalInfo.Add(await context.EmployeeAppraisalInfos.Where(x => x.AppraisalId == Id).SingleOrDefaultAsync());

            }
            return EmployeeAppraisalInfo;

        }


        public async Task<ResponseModel> GetEmployeeHistoricalView()
        {
            try
            {
                //var data = await (from employeeJob in context.EmployeeJobs
                //                  join employee in context.Employees on employeeJob.EmployeeId equals employee.EmployeeId
                //                  join JobClassCodes in context.Codes on employeeJob.JobClassCode equals JobClassCodes.Code1
                //                  join JobNameCodes in context.Codes on employeeJob.JobNameCode equals JobNameCodes.Code1 into codes
                //                  from code in codes.DefaultIfEmpty()
                //                  join RankCodes in context.Codes on employeeJob.RankCode equals RankCodes.Code1
                //                  select new
                //                  {
                //                      Id = employeeJob.EmployeeJobId,
                //                      employeeJob.EmployeeId,
                //                      employeeJob.NationalId,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      employeeJob.JobNumber,
                //                      JobClassCode = JobClassCodes.Value,
                //                      JobNameCode = code.Value,
                //                      RankCode = RankCodes.Value,
                //                      employeeJob.EmploymentTypeCode,
                //                      JobClassCodeKey = employeeJob.JobClassCode,
                //                      JobNameCodeKey = employeeJob.JobNameCode,
                //                      employeeJob.TransactionCode,
                //                      employeeJob.LocationCode,
                //                      StartDate = employeeJob.TransactionStartDate,
                //                      LastUpdateDate = employeeJob.LastUpdateDate,
                //                  }).ToListAsync();

                var data = context.EmployeeHistoricalInfos
                    .Include(a => a.Employee).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.Id,
                            EmployeeId = a.EmployeeId,
                            NationalId = a.NationalId,
                            Name = a.Employee.FirstNameAr + " " + a.Employee.SecondNameAr + " " + a.Employee.ThirdNameAr + " " + a.Employee.LastNameAr,
                            JobNumber = a.JobNumber,
                            JobClassCode = a.JobClassCode,
                            JobNameCode = a.JobNameCode,
                            RankCode = a.RankCode,
                            EmploymentTypeCode = a.EmploymentTypeCode,
                            JobClassCodeKey = a.JobClassCode,
                            JobNameCodeKey = a.JobNameCode,
                            TransactionCode = a.TransactionCode,
                            LocationCode = a.LocationCode,
                            StartDate = a.TransactionStartDate,
                            LastUpdateDate = a.LastUpdateDate
                        };
                    }).ToList();
                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<object> GetEmployees() =>
            await context.Employees.Select(x => new { Id = x.EmployeeId + ":" + x.NationalId, Value = x.FirstNameAr + " " + x.SecondNameAr + " " + x.ThirdNameAr + " " + x.LastNameAr }).ToListAsync();

        public async Task<ResponseModel> GetEmployeesAppraisalsView()
        {
            try
            {
                //var data = await (from employeepayAppraisals in context.EmployeeAppraisalInfos
                //                  join employee in context.Employees on employeepayAppraisals.EmployeeId equals employee.EmployeeId
                //                  select new
                //                  {
                //                      Id = employeepayAppraisals.AppraisalId,
                //                      employeepayAppraisals.EmployeeId,
                //                      employeepayAppraisals.NationalId,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      employeepayAppraisals.AppraisalTypeCode,
                //                      employeepayAppraisals.Result,
                //                      employeepayAppraisals.RatingCode,
                //                      StartDate = employeepayAppraisals.StartDate,
                //                      EndDate = employeepayAppraisals.EndDate,
                //                  }).ToListAsync();

                var data = context.EmployeeAppraisalInfos
                    .Include(a => a.Employee).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.AppraisalId,
                            EmployeeId = a.EmployeeId,
                            NationalId = a.NationalId,
                            Name = a.Employee.FirstNameAr + " " + a.Employee.SecondNameAr + " " + a.Employee.ThirdNameAr + " " + a.Employee.LastNameAr,
                            AppraisalTypeCode = a.AppraisalTypeCode,
                            Result = a.Result,
                            RatingCode = a.RatingCode,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate,
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<List<Employee>> GetEmployeesForSoap(List<long> Ids)
        {
            List<Employee> employees = new();
            try
            {
                foreach (var Id in Ids)
                {
                    employees.Add(employeeDapper.GetAllData($"select * from Employees where EmployeeId={Id}").Result.SingleOrDefault());
                }
            }
            catch (Exception ex)
            {
            }

            return employees;
        }

        public async Task<ResponseModel> GetEmployeesPaysView()
        {
            try
            {
                //var data = await (from employeepay in context.EmployeePayments
                //                  join rankCode in context.Codes on employeepay.RankCode equals rankCode.Code1
                //                  select new
                //                  {
                //                      Id = employeepay.EmployeePayId,
                //                      Name = employeepay.EmployeeName,
                //                      employeepay.ElementClassification,
                //                      employeepay.NetPay,
                //                      employeepay.Amount,
                //                      RankCode = rankCode.Value,
                //                      RankCodeKey = employeepay.RankCode,
                //                      employeepay.ElementCode,
                //                      employeepay.EmploymentTypeCode,
                //                      employeepay.StepId,
                //                      employeepay.ConsolidationSetId,
                //                      employeepay.HijriMonth,
                //                      employeepay.GregorianMonth,
                //                      employeepay.HijriYear,
                //                      employeepay.GregorianYear,
                //                      PaidDate = employeepay.PaidDate,
                //                  }).ToListAsync();

                var data = context.EmployeePayments
                    .Include(a => a.RankCodeNavigation).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.EmployeePayId,
                            Name = a.EmployeeName,
                            ElementClassification = a.ElementClassification,
                            NetPay = a.NetPay,
                            Amount = a.Amount,
                            RankCode = a.RankCodeNavigation.Code1,
                            RankCodeKey = a.RankCodeNavigation.Value,
                            ElementCode = a.ElementCode,
                            EmploymentTypeCode = a.EmploymentTypeCode,
                            StepId = a.StepId,
                            ConsolidationSetId = a.ConsolidationSetId,
                            HijriMonth = a.HijriMonth,
                            GregorianMonth = a.GregorianMonth,
                            HijriYear = a.HijriYear,
                            GregorianYear = a.GregorianYear,
                            PaidDate = a.PaidDate,
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<ResponseModel> GetEmployeesQualificationsView()
        {
            try
            {
                //var data = await (from employeeQualification in context.EmployeeQualifications
                //                  join qualificationCode in context.Codes on employeeQualification.QualificationCode equals qualificationCode.Code1
                //                  join MajorCodes in context.Codes on employeeQualification.MajorCode equals MajorCodes.Code1
                //                  join UniversityCode in context.Universities on employeeQualification.UniversityCode equals UniversityCode.UniversityId
                //                  join employee in context.Employees on employeeQualification.EmployeeId equals employee.EmployeeId
                //                  select new
                //                  {
                //                      Id = employeeQualification.QualificationId,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      MajorCode = MajorCodes.Value,
                //                      UniversityCode.UniversityName,
                //                      QualificationCode = qualificationCode.Value,
                //                      employeeQualification.QualificationStatus,
                //                      employeeQualification.NationalId,
                //                      QualificationCodeKey = employeeQualification.QualificationCode,
                //                      MajorCodeKey = employeeQualification.MajorCode,
                //                      employeeQualification.UniversityCode,
                //                      employeeQualification.TransactionType,
                //                  }).ToListAsync();

                var data = context.EmployeeQualifications
                    .Include(a => a.QualificationCodeNavigation)
                    .Include(a => a.MajorCodeNavigation)
                    .Include(a => a.UniversityCodeNavigation)
                    .Include(a => a.Employee).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.QualificationId,
                            Name = a.Employee.FirstNameAr + " " + a.Employee.SecondNameAr + " " + a.Employee.ThirdNameAr + " " + a.Employee.LastNameAr,
                            MajorCode = a.MajorCodeNavigation.Value,
                            UniversityName = a.UniversityCodeNavigation.UniversityName,
                            QualificationCode = a.QualificationCodeNavigation.Value,
                            QualificationStatus = a.QualificationStatus,
                            NationalId = a.NationalId,
                            QualificationCodeKey = a.QualificationCode,
                            MajorCodeKey = a.MajorCode,
                            UniversityCode = a.UniversityCode,
                            TransactionType = a.TransactionType
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<ResponseModel> GetEmployeesVacationsView()
        {
            try
            {
                //var data = await (from employeeVacations in context.EmployeeVacations
                //                  join vacationCode in context.Codes on employeeVacations.VacationCode equals vacationCode.Code1
                //                  join employee in context.Employees on employeeVacations.EmpoyeeId equals employee.EmployeeId
                //                  select new
                //                  {
                //                      Id = employeeVacations.VacationId,
                //                      EmployeeId = employeeVacations.EmpoyeeId,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      VacationCode = vacationCode.Value,
                //                      VacationCodeKey = employeeVacations.VacationCode,
                //                      employeeVacations.Period,
                //                      StartDate = employeeVacations.StartDate,
                //                      EndDate = employeeVacations.EndDate,
                //                  }).ToListAsync();

                var data = context.EmployeeVacations
                    .Include(a => a.VacationCodeNavigation)
                    .Include(a => a.Empoyee).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.VacationId,
                            EmployeeId = a.EmpoyeeId,
                            Name = a.Empoyee.FirstNameAr + " " + a.Empoyee.SecondNameAr + " " + a.Empoyee.ThirdNameAr + " " + a.Empoyee.LastNameAr,
                            VacationCode = a.VacationCodeNavigation.Value,
                            VacationCodeKey = a.VacationCode,
                            Period = a.Period,
                            StartDate = a.StartDate,
                            EndDate = a.EndDate
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<ResponseModel> GetEmployeesView()
        {
            try
            {
                //var data = await (from employee in context.Employees
                //                  join jobNameCode in context.Codes on employee.JobNameCode equals jobNameCode.Code1 into jobnamecodes
                //                  from jobnamecode in jobnamecodes.DefaultIfEmpty()
                //                  join transactionCode in context.Codes on employee.TransactionCode equals transactionCode.Code1 into codes
                //                  from code in codes.DefaultIfEmpty()
                //                  join rankCode in context.Codes on employee.RankCode equals rankCode.Code1 into rankcodes
                //                  from rankcode in rankcodes.DefaultIfEmpty()
                //                  join gender in context.Enums on employee.Gender equals gender.EnumId
                //                  join HealhStatus in context.Enums on employee.Healthstatus equals HealhStatus.EnumId
                //                  join MaritalStatus in context.Enums on employee.MaritalStatus equals MaritalStatus.EnumId
                //                  join Religion in context.Enums on employee.Religion equals Religion.EnumId into religioncodes
                //                  from Religion in religioncodes.DefaultIfEmpty()
                //                  select new
                //                  {
                //                      Id = employee.EmployeeId,
                //                      employee.NationalId,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      employee.BirthDate,
                //                      JobNameCode = jobnamecode.Value,
                //                      JobNameCodeKey = employee.JobNameCode,
                //                      JobClassCodeKey = employee.JobClassCode,
                //                      TransactionCode = code.Value,
                //                      TransactionCodeKey = employee.TransactionCode,
                //                      EmploymentTypeCodeKey = employee.EmploymentTypeCode,
                //                      employee.FirstGradeDate,
                //                      employee.EmployeeStatusCode,
                //                      employee.StepId,
                //                      employee.JobOrganizationId,
                //                      employee.JobOrganizationName,
                //                      employee.BasicSalary,
                //                      employee.LocationCode,
                //                      employee.MinistryHireDate,
                //                      employee.IsActive,
                //                      employee.LastUpdateDate,
                //                      RankCode = rankcode.Value,
                //                      RankCodeKey = employee.RankCode,
                //                      HealhStatus = HealhStatus.EnumValue,
                //                      Gender = gender.EnumValue,
                //                      MaritalStatus = MaritalStatus.EnumValue,
                //                      Religion = Religion.EnumValue,
                //                      Nationality = employee.NationalityCode

                //                  }
                //                  ).OrderBy(x => x.Id).ToListAsync();


                var data = context.Employees
                    .Include(a => a.BloodTypeNavigation)
                    .Include(a => a.GenderNavigation)
                    .Include(a => a.HealthstatusNavigation)
                    .Include(a => a.MaritalStatusNavigation)
                    .Include(a => a.ReligionNavigation).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.EmployeeId,
                            NationalId = a.NationalId,
                            Name = a.FirstNameAr + " " + a.SecondNameAr + " " + a.ThirdNameAr + " " + a.LastNameAr,
                            BirthDate = a.BirthDate,
                            JobNameCode = a.JobNameCode,
                            JobNameCodeKey = a.JobNameCode,
                            JobClassCodeKey = a.JobClassCode,
                            TransactionCode = a.TransactionCode,
                            TransactionCodeKey = a.TransactionCode,
                            EmploymentTypeCodeKey = a.EmploymentTypeCode,
                            FirstGradeDate = a.FirstGradeDate,
                            EmployeeStatusCode = a.EmployeeStatusCode,
                            StepId = a.StepId,
                            JobOrganizationId = a.JobOrganizationId,
                            JobOrganizationName = a.JobOrganizationName,
                            BasicSalary = a.BasicSalary,
                            LocationCode = a.LocationCode,
                            MinistryHireDate = a.MinistryHireDate,
                            IsActive = a.IsActive,
                            LastUpdateDate = a.LastUpdateDate,
                            RankCode = a.RankCode,
                            RankCodeKey = a.RankCode,
                            HealhStatus = a.HealthstatusNavigation.Value,
                            Gender = a.GenderNavigation.Value,
                            MaritalStatus = a.MaritalStatusNavigation.Value,
                            Religion = a.ReligionNavigation.Value,
                            Nationality = a.NationalityCode
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<List<EmployeeJob>> GetHistoricalInfoForSoap(List<long> Ids)
        {
            var data = new List<EmployeeJob>();
            foreach (var Id in Ids)
            {
                data.Add(await context.EmployeeJobs.Where(x => x.EmployeeJobId == Id).SingleOrDefaultAsync());
            }
            return data;
        }

        public async Task<List<Job>> GetJobInfoForSoap(List<long> Ids)
        {
            var data = new List<Job>();
            foreach (var Id in Ids)
            {
                data.Add(await context.Jobs.Where(x => x.JobPositionCode == Id).SingleOrDefaultAsync());
            }
            return data;
        }

        public async Task<ResponseModel> GetJobView()
        {
            try
            {
                //var data = await (from employeeJob in context.Jobs
                //                  join employee in context.Employees on employeeJob.EmployeeId equals employee.EmployeeId
                //                  join JobClassCodes in context.Codes on employeeJob.JobClassCode equals JobClassCodes.Code1
                //                  join JobNameCodes in context.Codes on employeeJob.JobNameCode equals JobNameCodes.Code1 into codes
                //                  from code in codes.DefaultIfEmpty()
                //                  join RankCodes in context.Codes on employeeJob.RankCode equals RankCodes.Code1
                //                  select new
                //                  {
                //                      Id = employeeJob.JobPositionCode,
                //                      Name = employee.FirstNameAr + " " + employee.SecondNameAr + " " + employee.ThirdNameAr + " " + employee.LastNameAr,
                //                      employeeJob.JobNumber,
                //                      JobClassCode = JobClassCodes.Value,
                //                      JobNameCode = code.Value,
                //                      RankCode = RankCodes.Value,
                //                      employeeJob.EmploymentTypeCode,
                //                      employeeJob.PositionOrganizationId,
                //                      employeeJob.EmployeeId,
                //                      employeeJob.PositionOrganizationName,
                //                      JobClassCodeKey = employeeJob.JobClassCode,
                //                      JobNameCodeKey = employeeJob.JobNameCode,
                //                      employeeJob.LocationCode,
                //                      employeeJob.PositionStatus,
                //                      StartDate = employeeJob.StartDate,
                //                      LastUpdateDate = employeeJob.LastUpdateDate,

                //                  }).ToListAsync();


                var data = context.Jobs.Include(a => a.Employee).ToList().Select(a =>
                    {
                        return new
                        {
                            Id = a.JobPositionCode,
                            Name = a.Employee != null ? (a.Employee.FirstNameAr + " " + a.Employee.SecondNameAr + " " + a.Employee.ThirdNameAr + " " + a.Employee.LastNameAr) : string.Empty,
                            JobNumber = a.JobNumber,
                            JobClassCode = context.Codes.Where(x => x.Code1 == a.JobClassCode && x.CategoryId == 7).Select(x => x.Value),
                            JobNameCode = context.Codes.Where(x => x.Code1 == a.JobNameCode && x.CategoryId == 4).Select(x => x.Value),
                            RankCode = a.RankCode,
                            EmploymentTypeCode = a.EmploymentTypeCode,
                            PositionOrganizationId = a.PositionOrganizationId,
                            EmployeeId = a.EmployeeId,
                            PositionOrganizationName = a.PositionOrganizationName,
                            JobClassCodeKey = a.JobClassCode,
                            JobNameCodeKey = a.JobNameCode,
                            LocationCode = a.LocationCode,
                            PositionStatus = a.PositionStatus,
                            StartDate = a.StartDate,
                            LastUpdateDate = a.LastUpdateDate
                        };
                    }).ToList();

                return new ResponseModel { Data = data, StatusCode = 200, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public async Task<List<EmployeePayment>> GetPayslipInfoForSoap(List<long> Ids)
        {
            var data = new List<EmployeePayment>();
            foreach (var Id in Ids)
            {
                data.Add(await context.EmployeePayments.Where(x => x.EmployeePayId == Id).SingleOrDefaultAsync());
            }
            return data;
        }

        public async Task<List<EmployeeQualification>> GetQualificationInfoForSoap(List<long> Ids)
        {
            var data = new List<EmployeeQualification>();

            try
            {
                foreach (var Id in Ids)
                {
                    data.Add(await context.EmployeeQualifications.Where(x => x.QualificationId == Id).SingleOrDefaultAsync());
                }
            }
            catch (Exception) { }
            return data;
        }

        public async Task<List<EmployeeVacation>> GetVacationInfoForSoap(List<long> Ids) => await context.EmployeeVacations.ToListAsync();

        public async Task<ResponseModel> SubmitEmployeeAppraisalInfo(EmployeeAppraisalInfoDTO employeeAppraisalInfoDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeAppraisalInfos);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeAppraisalInfo = mapper.Map<EmployeeAppraisalInfo>(employeeAppraisalInfoDTO);
            employeeAppraisalInfo.RequestIdentityId = request.RequestNumber;
            await context.EmployeeAppraisalInfos.AddAsync(employeeAppraisalInfo);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, RequestNumber = request.RequestNumber, Data = employeeAppraisalInfo, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeAppraisalInfoDTO, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeeHistoricalInfo(EmployeeJobDTO employeeJobDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeJobs);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeJob = mapper.Map<EmployeeJob>(employeeJobDTO);
            employeeJob.RequestIdentityId = request.RequestNumber;

            await context.EmployeeJobs.AddAsync(employeeJob);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, RequestNumber = request.RequestNumber, Data = employeeJob, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeJobDTO, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeeInfo(EmployeeDTO employeeDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.Employees);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employee = mapper.Map<Employee>(employeeDTO);
            employee.RequestIdentityId = request.RequestNumber;
            await context.Employees.AddAsync(employee);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, Data = employee, RequestNumber = request.RequestNumber, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeDTO, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeePaysInfo(EmployeePaymentDTO employeePaymentDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeePayments);

            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeePayment = mapper.Map<EmployeePayment>(employeePaymentDTO);
            employeePayment.RequestIdentityId = request.RequestNumber;
            await context.EmployeePayments.AddAsync(employeePayment);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, RequestNumber = request.RequestNumber, Data = employeePayment, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeePaymentDTO, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeeQualificationInfo(EmployeeQualificationDTO employeeQualificationDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeQualifications);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeQualification = mapper.Map<EmployeeQualification>(employeeQualificationDTO);
            employeeQualification.RequestIdentityId = request.RequestNumber;
            await context.EmployeeQualifications.AddAsync(employeeQualification);
            res += await context.SaveChangesAsync();
            return res == 1 ? new ResponseModel { IsSuccess = true, RequestNumber = request.RequestNumber, Data = employeeQualification, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeQualificationDTO, StatusCode = 400 };

        }

        public async Task<ResponseModel> SubmitEmployeeQualificationInfo(List<EmployeeQualificationDTO> employeeQualificationDTOs)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeQualifications);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeQualifications = mapper.Map<List<EmployeeQualification>>(employeeQualificationDTOs);
            foreach (var item in employeeQualifications)
            {
                item.RequestIdentityId = request.RequestNumber;

            }
            await context.EmployeeQualifications.AddRangeAsync(employeeQualifications);
            res += await context.SaveChangesAsync();
            return res == employeeQualificationDTOs.Count + 1 ? new ResponseModel { IsSuccess = true, Data = employeeQualifications, RequestNumber = request.RequestNumber, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeQualificationDTOs, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeeVacationInfo(EmployeeVacationDTO employeeVacationDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeVacations);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeVacation = mapper.Map<EmployeeVacation>(employeeVacationDTO);
            employeeVacation.RequestIdentityId = request.RequestNumber;

            await context.EmployeeVacations.AddAsync(employeeVacation);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, Data = employeeVacation, RequestNumber = request.RequestNumber, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeVacationDTO, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitEmployeeVacationInfo(List<EmployeeVacationDTO> employeeVacationDTOs)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.EmployeeVacations);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var employeeVacations = mapper.Map<List<EmployeeVacation>>(employeeVacationDTOs);
            foreach (var employeeVacation in employeeVacations)
            {
                //employeeVacation.Period = (int)employeeVacation.EndDate.Subtract(employeeVacation.StartDate).TotalDays;
                employeeVacation.RequestIdentityId = request.RequestNumber;
                await context.EmployeeVacations.AddAsync(employeeVacation);
                res += await context.SaveChangesAsync();
            }

            return res == employeeVacationDTOs.Count + 1 ? new ResponseModel { IsSuccess = true, Data = employeeVacations, RequestNumber = request.RequestNumber, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = employeeVacationDTOs, StatusCode = 400 };
        }

        public async Task<ResponseModel> SubmitJobInfo(JobDTO jobDTO)
        {
            var request = new RequestIdentity();
            request.Table = nameof(context.Jobs);
            await context.RequestIdentities.AddAsync(request);
            var res = await context.SaveChangesAsync();
            var job = mapper.Map<Job>(jobDTO);
            job.RequestIdentityId = request.RequestNumber;
            await context.Jobs.AddAsync(job);
            res += await context.SaveChangesAsync();
            return res == 2 ? new ResponseModel { IsSuccess = true, Data = job, RequestNumber = request.RequestNumber, StatusCode = 201 } : new ResponseModel { IsSuccess = false, Data = jobDTO, StatusCode = 400 };
        }

        public Task<bool> SaveResponseNumberForEmployee(string? NationalId, string? ResponseNumber)
        {
            bool result = false;
            try
            {
                //var res = employeeDapper.RunDML($"update Employees set ServiceResponseNumber = {ResponseNumber} where NationalId={NationalId}");
                Employee emp = context.Employees.Where(a => a.NationalId.Equals(NationalId)).FirstOrDefault();
                if (emp != null)
                {
                    emp.ServiceResponseNumber = ResponseNumber;
                    context.SaveChanges();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return Task.FromResult(result);
        }
    }
}
