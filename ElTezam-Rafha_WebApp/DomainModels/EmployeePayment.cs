using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeePayment
    {
        public int EmployeePayId { get; set; }
        public int? SubAgencyId { get; set; }
        public long EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmploymentTypeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public int? StepId { get; set; }
        public int ConsolidationSetId { get; set; }
        public string ConsolidationSetCode { get; set; } = null!;
        public string? ConsolidationSetDescription { get; set; }
        public int ElementCodeId { get; set; }
        public string ElementCode { get; set; } = null!;
        public double Amount { get; set; }
        public string ElementClassification { get; set; } = null!;
        public double NetPay { get; set; }
        public int HijriMonth { get; set; }
        public int HijriYear { get; set; }
        public int GregorianMonth { get; set; }
        public int GregorianYear { get; set; }
        public string PaidDate { get; set; } = null!;
        public int? RequestIdentityId { get; set; }
        public int? EmploymentTypeCodeId { get; set; }
        public int? RankCodeId { get; set; }

        public virtual Code ConsolidationSet { get; set; } = null!;
        public virtual Code ElementCodeNavigation { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Code? EmploymentTypeCodeNavigation { get; set; }
        public virtual Code? RankCodeNavigation { get; set; }
        public virtual RequestIdentity? RequestIdentity { get; set; }
    }
}
