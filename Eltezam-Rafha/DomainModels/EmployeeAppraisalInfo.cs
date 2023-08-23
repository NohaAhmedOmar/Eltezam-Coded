using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class EmployeeAppraisalInfo
    {
        public int AppraisalId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AppraisalTypeCode { get; set; } = null!;
        public string TransactionType { get; set; } = null!;
        public string Result { get; set; } = null!;
        public string RatingCode { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
