using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class EmployeeJob
    {
        public int EmployeeJobId { get; set; }
        public int? SubAgencyId { get; set; }
        public int EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string? JobClassDescription { get; set; }
        public string? JobCatChain { get; set; }
        public string JobNameCode { get; set; } = null!;
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string? EmploymentTypeDescription { get; set; }
        public string RankCode { get; set; } = null!;
        public string? DescriptionType { get; set; }
        public int? StepId { get; set; }
        public DateTime? StepDate { get; set; }
        public double? BasicSalary { get; set; }
        public int? DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? GradeDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string? TransactionDescription { get; set; }
        public DateTime TransactionStartDate { get; set; }
        public DateTime? TransactionEndDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Code EmploymentTypeCodeNavigation { get; set; } = null!;
        public virtual Code JobNameCodeNavigation { get; set; } = null!;
        public virtual Code RankCodeNavigation { get; set; } = null!;
    }
}
