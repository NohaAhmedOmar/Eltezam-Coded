using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class City
    {
        public City()
        {
            SubCities = new HashSet<SubCity>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int GovernorateId { get; set; }

        public virtual Governorate Governorate { get; set; } = null!;
        public virtual ICollection<SubCity> SubCities { get; set; }
    }
}
