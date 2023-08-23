using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Governorate
    {
        public Governorate()
        {
            Cities = new HashSet<City>();
        }

        public int GovernorateId { get; set; }
        public string GovernorateName { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
