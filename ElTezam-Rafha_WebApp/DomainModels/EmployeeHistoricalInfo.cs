using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeeHistoricalInfo
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string NationalId { get; set; } = null!;
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        public int JobClassCodeId { get; set; }
        public string JobNameCode { get; set; } = null!;
        public int JobNameCodeId { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public int EmploymentTypeCodeId { get; set; }
        public string RankCode { get; set; } = null!;
        public int RankCodeId { get; set; }
        public int? StepId { get; set; }
        public string LocationCode { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string TransactionStartDate { get; set; } = null!;
        public string LastUpdateDate { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
        public virtual Code EmploymentTypeCodeNavigation { get; set; } = null!;
        public virtual Code JobClassCodeNavigation { get; set; } = null!;
        public virtual Code JobNameCodeNavigation { get; set; } = null!;
        public virtual Code RankCodeNavigation { get; set; } = null!;
    }
}
