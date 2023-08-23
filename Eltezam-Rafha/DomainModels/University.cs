using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
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
