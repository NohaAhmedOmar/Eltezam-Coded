using Eltezam_Coded.Enums;

namespace Eltezam_Coded.DTOs
{
    public record EmployeeAppraisalInfoDTO
    {
        public int AppraisalId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NationalID { get; set; }
        public string AppraisalTypeCode { get; set; } = null!;
        public string TransactionType { get; set; } = AllEnums.TransactionType.Add.ToString();
        public string Result { get; set; } = null!;
        public string RatingCode { get; set; } = null!;
        public Int64 EmployeeId { get; set; }
    }
}
