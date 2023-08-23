using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeeAppraisalInfo
    {
        public int AppraisalId { get; set; }
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public string AppraisalTypeCode { get; set; } = null!;
        public string TransactionType { get; set; } = null!;
        public string Result { get; set; } = null!;
        public string RatingCode { get; set; } = null!;
        public long EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public int? RequestIdentityId { get; set; }
        public int? SubAgencyId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual RequestIdentity? RequestIdentity { get; set; }
    }
}
