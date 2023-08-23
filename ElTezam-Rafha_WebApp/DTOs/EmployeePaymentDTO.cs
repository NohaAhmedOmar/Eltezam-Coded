namespace Eltezam_Coded.DTOs
{
    public record EmployeePaymentDTO
    {
        public int EmployeePayId { get; set; }
        public int? SubAgencyId { get; set; }
        public Int64 EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmploymentTypeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public int? StepId { get; set; }
        public int ConsolidationSetId { get; set; }
        public string? ConsolidationSetDescription { get; set; }
        public int ElementCode { get; set; }
        public double Amount { get; set; }
        public string ElementClassification { get; set; } = null!;
        public double NetPay { get; set; }
        public int HijriMonth { get; set; }
        public int HijriYear { get; set; }
        public int GregorianMonth { get; set; }
        public int GregorianYear { get; set; }
        public string PaidDate { get; set; } = null!;
    }
}
