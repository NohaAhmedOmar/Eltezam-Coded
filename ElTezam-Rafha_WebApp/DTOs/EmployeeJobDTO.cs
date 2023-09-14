namespace Eltezam_Coded.DTOs
{
    public record EmployeeJobDTO
    {
        public int EmployeeJobId { get; set; }
        public int? SubAgencyId { get; set; } = 2122;
        public Int64 EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string? JobClassDescription { get; set; }
        public string? JobCatChain { get; set; }
        public string JobNameCode { get; set; } = null!;
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string? EmploymentTypeDescription { get; set; }
        public string RankCode { get; set; } = null!;
        public string? DescriptionType { get; set; }
        public int? StepId { get; set; }
        public string? StepDate { get; set; }
        public double? BasicSalary { get; set; }
        public int? DecisionNumber { get; set; }
        public string? DecisionDate { get; set; }
        public string? GradeDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string TransactionCode { get; set; } = null!;
        public string? TransactionDescription { get; set; }
        public string TransactionStartDate { get; set; }
        public string? TransactionEndDate { get; set; }
        public string LastUpdateDate { get; set; } = DateTime.Now.ToString();   
    }
}
