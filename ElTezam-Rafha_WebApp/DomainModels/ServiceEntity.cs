using System;
using System.Collections.Generic;

namespace ElTezam_Coded_WebApp.DomainModels
{
    public partial class ServiceEntity
    {
        public ServiceEntity()
        {
            ServiceResponses = new HashSet<ServiceResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }
    }
}
