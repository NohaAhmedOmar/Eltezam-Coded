using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EmployeeQualification
    {
        public int QualificationId { get; set; }
        public string QualificationCode { get; set; } = null!;
        public int QualificationCodeId { get; set; }
        public int MajorCodeId { get; set; }
        public string MajorCode { get; set; } = null!;
        public int UniversityCode { get; set; }
        public string? CityName { get; set; }
        public string? CountryCode { get; set; }
        public string? Grade { get; set; }
        public double? Score { get; set; }
        public double? ScoreOutOf { get; set; }
        public string TransactionType { get; set; } = null!;
        public string? GraduationDate { get; set; }
        public string QualificationStatus { get; set; } = null!;
        public long EmployeeId { get; set; }
        public string? IqamaNumber { get; set; }
        public string? NationalId { get; set; }
        public int? RequestIdentityId { get; set; }
        public int? SubAgencyId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Code MajorCodeNavigation { get; set; } = null!;
        public virtual Code QualificationCodeNavigation { get; set; } = null!;
        public virtual RequestIdentity? RequestIdentity { get; set; }
        public virtual University UniversityCodeNavigation { get; set; } = null!;
    }
}
