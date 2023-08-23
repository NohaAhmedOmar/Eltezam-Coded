using System.Runtime.Serialization;

namespace Eltezam_Coded.DTOs
{
    [DataContract]
    public record EmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string FirstNameAr { get; set; } = null!;
        [DataMember]
        public string SecondNameAr { get; set; } = null!;
        [DataMember]
        public string? ThirdNameAr { get; set; }
        [DataMember]
        public string LastNameAr { get; set; } = null!;
        [DataMember]
        public string FirstNameEn { get; set; } = null!;
        [DataMember]
        public string SecondNameEn { get; set; } = null!;
        [DataMember]
        public string? ThirdNameEn { get; set; }
        [DataMember]
        public string LastNameEn { get; set; } = null!;
        [DataMember]    
        public string BirthDate { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public string NationalityCode { get; set; } = null!;
        [DataMember]    
        public int Religion { get; set; }
        [DataMember]
        public int? BloodType { get; set; }
        [DataMember]
        public string? Mobile { get; set; }
        [DataMember]
        public string? EmailAddress { get; set; }
        [DataMember]
        public int MaritalStatus { get; set; }
        [DataMember]
        public int Healthstatus { get; set; }
        [DataMember]
        public string EmployeeStatusCode { get; set; } = null!;
        [DataMember]
        public int JobNumber { get; set; }
        [DataMember]
        public int JobClassCode { get; set; }
        [DataMember]    
        public string? JobClassDescription { get; set; }
        [DataMember]
        public string? JobCatChain { get; set; }
        [DataMember]
        public int? JobNameCode { get; set; }
        [DataMember]
        public string? JobNameDescription { get; set; }
        [DataMember]
        public string EmploymentTypeCode { get; set; } = null!;
        [DataMember]
        public string? EmploymentTypeDescription { get; set; }
        [DataMember]
        public string RankCode { get; set; } = null!;
        [DataMember]
        public int StepId { get; set; }
        [DataMember]
        public string? StepDate { get; set; }
        [DataMember]
        public string FirstGradeDate { get; set; }
        [DataMember]
        public int? ActualJobNameCode { get; set; }
        [DataMember]
        public string? ActualJobNameDescription { get; set; }
        [DataMember]
        public string JobOrganizationId { get; set; } = null!;
        [DataMember]
        public string JobOrganizationName { get; set; } = null!;
        [DataMember]
        public double BasicSalary { get; set; }
        [DataMember]
        public string? ActualOrganizationId { get; set; }
        [DataMember]
        public string? ActualOrganizationName { get; set; }
        [DataMember]
        public string? NextPromotionDate { get; set; }
        [DataMember]
        public string? GovernmentHireDate { get; set; }
        [DataMember]
        public int LocationCode { get; set; }
        [DataMember]
        public string MinistryHireDate { get; set; }
        [DataMember]    
        public double? RemainingAnnualBalance { get; set; }
        [DataMember]    
        public double? RemainingBusinessBalance { get; set; }
        [DataMember]
        public int? TransactionCode { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]    
        public string TerminationReasonCode { get; set; } = null!;
        [DataMember]
        public string TerminationDate { get; set; }
        [DataMember]
        public string LastUpdateDate { get; set; }
    }
}
