using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAppraisalInfos = new HashSet<EmployeeAppraisalInfo>();
            EmployeeHistoricalInfos = new HashSet<EmployeeHistoricalInfo>();
            EmployeeJobs = new HashSet<EmployeeJob>();
            EmployeePayments = new HashSet<EmployeePayment>();
            EmployeeQualifications = new HashSet<EmployeeQualification>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
            Jobs = new HashSet<Job>();
        }

        public long EmployeeId { get; set; }
        public string FirstNameAr { get; set; } = null!;
        public string SecondNameAr { get; set; } = null!;
        public string? ThirdNameAr { get; set; }
        public string LastNameAr { get; set; } = null!;
        public string? FirstNameEn { get; set; }
        public string? SecondNameEn { get; set; }
        public string? ThirdNameEn { get; set; }
        public string? LastNameEn { get; set; }
        public string BirthDate { get; set; } = null!;
        public int Gender { get; set; }
        public string GenderCode { get; set; } = null!;
        public string NationalityCode { get; set; } = null!;
        public int? Religion { get; set; }
        public string? ReligionCode { get; set; }
        public int? BloodType { get; set; }
        public string? BloodTypeCode { get; set; }
        public string? Mobile { get; set; }
        public string? EmailAddress { get; set; }
        public int MaritalStatus { get; set; }
        public string MaritalStatusCode { get; set; } = null!;
        public int Healthstatus { get; set; }
        public string HealthstatusCode { get; set; } = null!;
        public string EmployeeStatusCode { get; set; } = null!;
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string? JobClassDescription { get; set; }
        public string? JobCatChain { get; set; }
        public string? JobNameCode { get; set; }
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string? EmploymentTypeDescription { get; set; }
        public string RankCode { get; set; } = null!;
        public int StepId { get; set; }
        public string? StepDate { get; set; }
        public string FirstGradeDate { get; set; } = null!;
        public int? ActualJobNameCode { get; set; }
        public string? ActualJobNameDescription { get; set; }
        public string JobOrganizationId { get; set; } = null!;
        public string JobOrganizationName { get; set; } = null!;
        public double BasicSalary { get; set; }
        public string? ActualOrganizationId { get; set; }
        public string? ActualOrganizationName { get; set; }
        public string? NextPromotionDate { get; set; }
        public string? GovernmentHireDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string MinistryHireDate { get; set; } = null!;
        public double? RemainingAnnualBalance { get; set; }
        public double? RemainingBusinessBalance { get; set; }
        public string? TransactionCode { get; set; }
        public bool IsActive { get; set; }
        public string? TerminationReasonCode { get; set; }
        public string? TerminationDate { get; set; }
        public string LastUpdateDate { get; set; } = null!;
        public string? IqamaNumber { get; set; }
        public string? NationalId { get; set; }
        public int? RequestIdentityId { get; set; }
        public int? SubAgencyId { get; set; }
        public string? ServiceResponseNumber { get; set; }

        public virtual Code? BloodTypeNavigation { get; set; }
        public virtual Code GenderNavigation { get; set; } = null!;
        public virtual Code HealthstatusNavigation { get; set; } = null!;
        public virtual Code MaritalStatusNavigation { get; set; } = null!;
        public virtual Code? ReligionNavigation { get; set; }
        public virtual RequestIdentity? RequestIdentity { get; set; }
        public virtual ICollection<EmployeeAppraisalInfo> EmployeeAppraisalInfos { get; set; }
        public virtual ICollection<EmployeeHistoricalInfo> EmployeeHistoricalInfos { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
