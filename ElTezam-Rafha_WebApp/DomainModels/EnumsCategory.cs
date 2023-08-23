using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class EnumsCategory
    {
        public EnumsCategory()
        {
            Enums = new HashSet<Enum>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Enum> Enums { get; set; }
    }
}
