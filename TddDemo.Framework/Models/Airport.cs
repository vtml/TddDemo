using System;
using System.Collections.Generic;

namespace TddDemo.Framework.Models
{
    public partial interface IAirport
    {
        Guid Id { get; set; }
        
        string AirportCode { get; set; }

        string AirportName { get; set; }

        string Latitude { get; set; }

        string Longitude { get; set; }
    }

    public partial class Airport : IAirport
    {
        public Guid Id { get; set; }        
        public virtual string AirportCode { get; set; }
        public virtual string AirportName { get; set; }
        public virtual IEnumerable<Guid> City { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
    }
}
