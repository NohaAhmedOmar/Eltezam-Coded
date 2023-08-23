using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class CodesTemp
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual CodeCategory Category { get; set; } = null!;
    }
}
