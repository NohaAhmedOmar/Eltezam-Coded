using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Code
    {
        public Code()
        {
            EmployeeBloodTypeNavigations = new HashSet<Employee>();
            EmployeeGenderNavigations = new HashSet<Employee>();
            EmployeeHealthstatusNavigations = new HashSet<Employee>();
            EmployeeHistoricalInfoEmploymentTypeCodeNavigations = new HashSet<EmployeeHistoricalInfo>();
            EmployeeHistoricalInfoJobClassCodeNavigations = new HashSet<EmployeeHistoricalInfo>();
            EmployeeHistoricalInfoJobNameCodeNavigations = new HashSet<EmployeeHistoricalInfo>();
            EmployeeHistoricalInfoRankCodeNavigations = new HashSet<EmployeeHistoricalInfo>();
            EmployeeJobEmploymentTypeCodeNavigations = new HashSet<EmployeeJob>();
            EmployeeJobRankCodeNavigations = new HashSet<EmployeeJob>();
            EmployeeMaritalStatusNavigations = new HashSet<Employee>();
            EmployeePaymentConsolidationSets = new HashSet<EmployeePayment>();
            EmployeePaymentElementCodeNavigations = new HashSet<EmployeePayment>();
            EmployeePaymentEmploymentTypeCodeNavigations = new HashSet<EmployeePayment>();
            EmployeePaymentRankCodeNavigations = new HashSet<EmployeePayment>();
            EmployeeQualificationMajorCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeQualificationQualificationCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeReligionNavigations = new HashSet<Employee>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
        }

        public int Id { get; set; }
        public string Code1 { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual CodeCategory Category { get; set; } = null!;
        public virtual ICollection<Employee> EmployeeBloodTypeNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeGenderNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeHealthstatusNavigations { get; set; }
        public virtual ICollection<EmployeeHistoricalInfo> EmployeeHistoricalInfoEmploymentTypeCodeNavigations { get; set; }
        public virtual ICollection<EmployeeHistoricalInfo> EmployeeHistoricalInfoJobClassCodeNavigations { get; set; }
        public virtual ICollection<EmployeeHistoricalInfo> EmployeeHistoricalInfoJobNameCodeNavigations { get; set; }
        public virtual ICollection<EmployeeHistoricalInfo> EmployeeHistoricalInfoRankCodeNavigations { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobEmploymentTypeCodeNavigations { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobRankCodeNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeMaritalStatusNavigations { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentConsolidationSets { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentElementCodeNavigations { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentEmploymentTypeCodeNavigations { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentRankCodeNavigations { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualificationMajorCodeNavigations { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualificationQualificationCodeNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeReligionNavigations { get; set; }
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
    }
}
