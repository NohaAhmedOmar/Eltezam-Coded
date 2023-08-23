using System;
using System.Collections.Generic;

namespace Eltezam_Coded.DomainModels
{
    public partial class CodeCategory
    {
        public CodeCategory()
        {
            Codes = new HashSet<Code>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Code> Codes { get; set; }
    }
}
