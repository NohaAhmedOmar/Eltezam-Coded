using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class ServiceResponse
    {
        public int Id { get; set; }
        public int ServiceEntity { get; set; }
        public long EmployeeId { get; set; }
        public string ResponseNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ServiceEntity ServiceEntityNavigation { get; set; } = null!;
    }
}
