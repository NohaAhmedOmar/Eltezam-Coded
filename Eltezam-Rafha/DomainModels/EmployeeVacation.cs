using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class EmployeeVacation
    {
        public int VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Period { get; set; }
        public int VacationCode { get; set; }
        public string TransactionType { get; set; } = null!;
        public int? DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public int EmpoyeeId { get; set; }

        public virtual Employee Empoyee { get; set; } = null!;
        //public virtual Enum VacationCodeNavigation { get; set; } = null!;
        public virtual Code VacationCodeNavigation { get; set; } = null!;
    }
}
