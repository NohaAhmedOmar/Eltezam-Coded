using System.ComponentModel.DataAnnotations;

namespace ElTezam_Coded_WebApp.DTOs
{
    public record JobDTO
    {
        public int JobPositionCode { get; set; }
        public int? SubAgencyId { get; set; }
        public Int64? EmployeeId { get; set; }
        [StringLength(11)]
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        [StringLength(50)]
        public string? JobCatChain { get; set; }
        public string JobNameCode { get; set; } = null!;
        [StringLength(100)]
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public int PositionOrganizationID { get; set; }
        [StringLength(100)]

        public string PositionOrganizationName { get; set; } = null!;
        [StringLength(100)]

        public string PositionStatus { get; set; } = null!;
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string JobTransactionCode { get; set; } = null!;
        public string? TransactionDescription { get; set; }
        public string? VacantDate { get; set; }
        public string LastUpdateDate { get; set; } = DateTime.Now.ToString();
    }
}
