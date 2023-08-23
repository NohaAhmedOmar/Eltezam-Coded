using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class CodeCategory
    {
        public CodeCategory()
        {
            Codes = new HashSet<Code>();
            CodesTemps = new HashSet<CodesTemp>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Code> Codes { get; set; }
        public virtual ICollection<CodesTemp> CodesTemps { get; set; }
    }
}
