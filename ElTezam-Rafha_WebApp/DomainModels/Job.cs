using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Job
    {
        public Job()
        {
            ServiceResponses = new HashSet<ServiceResponse>();
        }

        public int Id { get; set; }
        public int? SubAgencyId { get; set; }
        public long? EmployeeId { get; set; }
        public string? NationalId { get; set; }
        public string? IqamaNumber { get; set; }
        public int JobNumber { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string? JobCatChain { get; set; }
        public string JobNameCode { get; set; } = null!;
        public string? JobNameDescription { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public int PositionOrganizationId { get; set; }
        public string PositionOrganizationName { get; set; } = null!;
        public string PositionStatus { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string? EndDate { get; set; }
        public string LocationCode { get; set; } = null!;
        public string? JobTransactionCode { get; set; }
        public string? TransactionDescription { get; set; }
        public string? VacantDate { get; set; }
        public string LastUpdateDate { get; set; } = null!;
        public int? RequestIdentityId { get; set; }
        public string JobPositionCode { get; set; } = null!;

        public virtual Employee? Employee { get; set; }
        public virtual RequestIdentity? RequestIdentity { get; set; }
        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }
    }
}
