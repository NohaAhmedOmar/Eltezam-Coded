using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Eltezam_Coded.DomainModels
{
    public partial class Enum
    {
        public Enum()
        {
            EmployeeBloodTypeNavigations = new HashSet<Employee>();
            EmployeeGenderNavigations = new HashSet<Employee>();
            EmployeeHealthstatusNavigations = new HashSet<Employee>();
            EmployeeMaritalStatusNavigations = new HashSet<Employee>();
            EmployeePaymentConsolidationSets = new HashSet<EmployeePayment>();
            EmployeePaymentElementCodeNavigations = new HashSet<EmployeePayment>();
            EmployeeQualificationMajorCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeQualificationQualificationCodeNavigations = new HashSet<EmployeeQualification>();
            EmployeeReligionNavigations = new HashSet<Employee>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
        }

        public int EnumId { get; set; }
        public string EnumValue { get; set; } = null!;
        public int CategoryId { get; set; }
        [XmlIgnore]
        public virtual EnumsCategory Category { get; set; } = null!;
        [XmlIgnore]
        public virtual ICollection<Employee> EmployeeBloodTypeNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> EmployeeGenderNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> EmployeeHealthstatusNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> EmployeeMaritalStatusNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<EmployeePayment> EmployeePaymentConsolidationSets { get; set; }
        [XmlIgnore]
        public virtual ICollection<EmployeePayment> EmployeePaymentElementCodeNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<EmployeeQualification> EmployeeQualificationMajorCodeNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<EmployeeQualification> EmployeeQualificationQualificationCodeNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<Employee> EmployeeReligionNavigations { get; set; }
        [XmlIgnore]
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }
    }
}
