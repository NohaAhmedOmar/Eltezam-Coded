using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class SubCity
    {
        public int SubCityId { get; set; }
        public string SubCityName { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
    }
}
