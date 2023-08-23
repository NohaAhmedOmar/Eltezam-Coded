using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Nationality
    {
        public int NationalityId { get; set; }
        public string NationalityCode { get; set; } = null!;
        public string NationalityDescription { get; set; } = null!;
    }
}
