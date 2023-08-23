using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class Code
    {
        public Code()
        {
            EmployeeJobEmploymentTypeCodeNavigations = new HashSet<EmployeeJob>();
            EmployeeJobJobNameCodeNavigations = new HashSet<EmployeeJob>();
            EmployeeJobRankCodeNavigations = new HashSet<EmployeeJob>();
            EmployeePaymentEmploymentTypeCodeNavigations = new HashSet<EmployeePayment>();
            EmployeePaymentRankCodeNavigations = new HashSet<EmployeePayment>();

            EmployeePaymentConsolidationSets = new HashSet<EmployeePayment>();
            EmployeePaymentElementCodeNavigations = new HashSet<EmployeePayment>();
            EmployeeQualificationMajorCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeQualificationQualificationCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
            EmployeeBloodTypeNavigations = new HashSet<Employee>();
            EmployeeGenderNavigations = new HashSet<Employee>();
            EmployeeHealthstatusNavigations = new HashSet<Employee>();
            EmployeeMaritalStatusNavigations = new HashSet<Employee>();
            EmployeeReligionNavigations = new HashSet<Employee>();
        }

        public string Code1 { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual CodeCategory Category { get; set; } = null!;
        public virtual ICollection<EmployeeJob> EmployeeJobEmploymentTypeCodeNavigations { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobJobNameCodeNavigations { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobRankCodeNavigations { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentEmploymentTypeCodeNavigations { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentRankCodeNavigations { get; set; }

        public virtual ICollection<EmployeePayment> EmployeePaymentConsolidationSets { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePaymentElementCodeNavigations { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualificationMajorCodeNavigations { get; set; }
        public virtual ICollection<EmployeeQualification> EmployeeQualificationQualificationCodeNavigations { get; set; }
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
        public virtual ICollection<Employee> EmployeeBloodTypeNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeGenderNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeHealthstatusNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeMaritalStatusNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeReligionNavigations { get; set; }
    }
}
