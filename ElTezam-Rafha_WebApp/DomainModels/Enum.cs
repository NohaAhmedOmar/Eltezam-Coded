using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class Enum
    {
        public int EnumId { get; set; }
        public string EnumValue { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual EnumsCategory Category { get; set; } = null!;
    }
}
