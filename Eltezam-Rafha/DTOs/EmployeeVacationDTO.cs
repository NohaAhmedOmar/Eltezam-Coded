namespace Eltezam_Coded.DTOs
{
    public record EmployeeVacationDTO
    {
        public int VacationId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Period { get; set; }
        public int VacationCode { get; set; }
        public string TransactionType { get; set; } = null!;
        public int? DecisionNumber { get; set; }
        public string? DecisionDate { get; set; }
        public int EmpoyeeId { get; set; }
    }
}
