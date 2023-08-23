using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeeVacation
    {
        public long VacationId { get; set; }
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int Period { get; set; }
        public string VacationCode { get; set; } = null!;
        public int VacationCodeId { get; set; }
        public string TransactionType { get; set; } = null!;
        public int? DecisionNumber { get; set; }
        public string? DecisionDate { get; set; }
        public long EmpoyeeId { get; set; }
        public string? IqamaNumber { get; set; }
        public string? NationalId { get; set; }
        public int? RequestIdentityId { get; set; }
        public int? SubAgencyId { get; set; }

        public virtual Employee Empoyee { get; set; } = null!;
        public virtual RequestIdentity? RequestIdentity { get; set; }
        public virtual Code VacationCodeNavigation { get; set; } = null!;
    }
}
