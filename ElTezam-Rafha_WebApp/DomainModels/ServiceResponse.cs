using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class ServiceResponse
    {
        public int Id { get; set; }
        public int ServiceEntity { get; set; }
        public long? EmployeeId { get; set; }
        public int? AppraisalId { get; set; }
        public long? HistoricalId { get; set; }
        public int? EmployeeJobId { get; set; }
        public int? EmployeePayId { get; set; }
        public int? QualificationId { get; set; }
        public long? VacationId { get; set; }
        public string ResponseNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmployeeAppraisalInfo? Appraisal { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual EmployeeJob? EmployeeJob { get; set; }
        public virtual EmployeePayment? EmployeePay { get; set; }
        public virtual EmployeeHistoricalInfo? Historical { get; set; }
        public virtual EmployeeQualification? Qualification { get; set; }
        public virtual ServiceEntity ServiceEntityNavigation { get; set; } = null!;
        public virtual EmployeeVacation? Vacation { get; set; }
    }
}
