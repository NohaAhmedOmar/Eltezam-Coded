namespace Eltezam_Coded.DTOs
{
    public record EmployeeQualificationDTO
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
        public string? GraduationDate { get; set; }
        public string QualificationStatus { get; set; } = null!;
        public int EmployeeId { get; set; }

    }
}
