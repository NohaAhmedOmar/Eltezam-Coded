using Eltezam_Coded.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Eltezam_Coded.DTOs
{
    public record EmployeeDTO
    {
        
        public Int64 EmployeeId { get; set; }
        [StringLength(10)]
        public string? NationalID { get; set; }
        public string? IqamaNumber { get; set; }
        public string FirstNameAr { get; set; } = null!;
        
        public string SecondNameAr { get; set; } = null!;
        
        public string? ThirdNameAr { get; set; }
        
        public string LastNameAr { get; set; } = null!;
        
        public string FirstNameEn { get; set; } = null!;
        
        public string SecondNameEn { get; set; } = null!;
        
        public string? ThirdNameEn { get; set; }
        
        public string LastNameEn { get; set; } = null!;
            
        public string BirthDate { get; set; }
        
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
        
        public string JobClassCode { get; set; }
            
        public string? JobClassDescription { get; set; }
        
        public string? JobCatChain { get; set; }
        
        public string? JobNameCode { get; set; }
        
        public string? JobNameDescription { get; set; }
        
        public string EmploymentTypeCode { get; set; } = null!;
        
        public string? EmploymentTypeDescription { get; set; }
        
        public string RankCode { get; set; } = null!;
        
        public int StepId { get; set; }
        
        public string? StepDate { get; set; }
        
        public string FirstGradeDate { get; set; }
        
        public int? ActualJobNameCode { get; set; }
        
        public string? ActualJobNameDescription { get; set; }
        
        public string JobOrganizationId { get; set; } = null!;
        
        public string JobOrganizationName { get; set; } = null!;
        
        public double BasicSalary { get; set; }
        
        public string? ActualOrganizationId { get; set; }
        
        public string? ActualOrganizationName { get; set; }
        
        public string? NextPromotionDate { get; set; }
        
        public string? GovernmentHireDate { get; set; }
        
        public string LocationCode { get; set; }
        
        public string MinistryHireDate { get; set; }
            
        public double? RemainingAnnualBalance { get; set; }
            
        public double? RemainingBusinessBalance { get; set; }
        
        public string? TransactionCode { get; set; }
        
        public bool IsActive { get; set; }
            
        public string TerminationReasonCode { get; set; } =AllEnums.TransactionType.Add.ToString();
        
        public string TerminationDate { get; set; }
        
        public string LastUpdateDate { get; set; }=DateTime.Now.Day.ToString()+"-"+ DateTime.Now.Month.ToString()+"-"+ DateTime.Now.Year.ToString();
    }
}
