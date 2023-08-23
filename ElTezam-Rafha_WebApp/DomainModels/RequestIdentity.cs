using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class RequestIdentity
    {
        public RequestIdentity()
        {
            EmployeeAppraisalInfos = new HashSet<EmployeeAppraisalInfo>();
            EmployeeJobs = new HashSet<EmployeeJob>();
            EmployeePayments = new HashSet<EmployeePayment>();
            EmployeeQualifications = new HashSet<EmployeeQualification>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
            Employees = new HashSet<Employee>();
            Jobs = new HashSet<Job>();
        }

        public int RequestNumber { get; set; }
        public string Table { get; set; } = null!;

        public virtual ICollection<EmployeeAppraisalInfo> EmployeeAppraisalInfos { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
