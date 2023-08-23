using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAppraisalInfos = new HashSet<EmployeeAppraisalInfo>();
            EmployeeJobs = new HashSet<EmployeeJob>();
            EmployeePayments = new HashSet<EmployeePayment>();
            EmployeeQualifications = new HashSet<EmployeeQualification>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
        }

        public int EmployeeId { get; set; }
        public string FirstNameAr { get; set; } = null!;
        public string SecondNameAr { get; set; } = null!;
        public string? ThirdNameAr { get; set; }
        public string LastNameAr { get; set; } = null!;
        public string FirstNameEn { get; set; } = null!;
        public string SecondNameEn { get; set; } = null!;
        public string? ThirdNameEn { get; set; }
        public string LastNameEn { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string NationalityCode { get; set; } = null!;
        public int Religion { get; set; }
        public int? BloodType { get; set; }
        public string? Mobile { get; set; }
        public string? EmailAddress { get; set; }
        public int MaritalStatus { get; set; }
        public int Healthstatus { get; set; }
        public string EmployeeStatusCode { get; set; } = null!;
        public int JobNumber { get; set; }
        public int JobClassCode { get; set; }
        public string? JobClassDescription { get; set; }
        public string? JobCatChain { get; set; }
        public int? JobNameCode { get; set; }
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string? EmploymentTypeDescription { get; set; }
        public string RankCode { get; set; } = null!;
        public int StepId { get; set; }
        public DateTime? StepDate { get; set; }=DateTime.Now;
        public DateTime FirstGradeDate { get; set; }
        public int? ActualJobNameCode { get; set; }
        public string? ActualJobNameDescription { get; set; }
        public string JobOrganizationId { get; set; } = null!;
        public string JobOrganizationName { get; set; } = null!;
        public double BasicSalary { get; set; }
        public string? ActualOrganizationId { get; set; }
        public string? ActualOrganizationName { get; set; }
        public DateTime? NextPromotionDate { get; set; }=DateTime.Now;
        public DateTime? GovernmentHireDate { get; set; } = DateTime.Now;   
        public int LocationCode { get; set; }
        public DateTime MinistryHireDate { get; set; }
        public double? RemainingAnnualBalance { get; set; }
        public double? RemainingBusinessBalance { get; set; }
        public int? TransactionCode { get; set; }
        public bool IsActive { get; set; }
        public string TerminationReasonCode { get; set; } = null!;
        public DateTime TerminationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Enum? BloodTypeNavigation { get; set; }
        public virtual Enum GenderNavigation { get; set; } = null!;
        public virtual Enum HealthstatusNavigation { get; set; } = null!;
        public virtual Enum MaritalStatusNavigation { get; set; } = null!;
        public virtual Enum ReligionNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeAppraisalInfo> EmployeeAppraisalInfos { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
    }
}
