using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class University
    {
        public University()
        {
            EmployeeQualifications = new HashSet<EmployeeQualification>();
        }

        public int UniversityId { get; set; }
        public string UniversityName { get; set; } = null!;

        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
    }
}
