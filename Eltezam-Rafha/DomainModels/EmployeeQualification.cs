using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class EmployeeQualification
    {
        public int QualificationId { get; set; }
        public int QualificationCode { get; set; }
        public int MajorCode { get; set; }
        public int UniversityCode { get; set; }
        public string? CityName { get; set; }
        public string? CountryCode { get; set; }
        public string? Grade { get; set; }
        public double? Score { get; set; }
        public double? ScoreOutOf { get; set; }
        public string TransactionType { get; set; } = null!;
        public DateTime? GraduationDate { get; set; }
        public string QualificationStatus { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        //public virtual Enum MajorCodeNavigation { get; set; } = null!;
        //public virtual Enum QualificationCodeNavigation { get; set; } = null!;
        public virtual Code MajorCodeNavigation { get; set; } = null!;
        public virtual Code QualificationCodeNavigation { get; set; } = null!;

        public virtual University UniversityCodeNavigation { get; set; } = null!;
    }
}
