using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeeJob
    {
        public EmployeeJob()
        {
            ServiceResponses = new HashSet<ServiceResponse>();
        }

        public int EmployeeJobId { get; set; }
        public int? SubAgencyId { get; set; }
        public long EmployeeId { get; set; }
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
        public string? StepDate { get; set; }
        public double? BasicSalary { get; set; }
        public int? DecisionNumber { get; set; }
        public string? DecisionDate { get; set; }
        public string? GradeDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string? TransactionDescription { get; set; }
        public string TransactionStartDate { get; set; } = null!;
        public string? TransactionEndDate { get; set; }
        public string LastUpdateDate { get; set; } = null!;
        public int? RequestIdentityId { get; set; }
        public int? EmploymentTypeCodeId { get; set; }
        public int? RankCodeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Code? EmploymentTypeCodeNavigation { get; set; }
        public virtual Code? RankCodeNavigation { get; set; }
        public virtual RequestIdentity? RequestIdentity { get; set; }
        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }
    }
}
