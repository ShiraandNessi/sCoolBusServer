using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Station
    {
        public Station()
        {
            Families = new HashSet<Family>();
            StationOfRoutes = new HashSet<StationOfRoute>();
        }

        public int Id { get; set; }
       
        public string Address { get; set; }
        [JsonIgnore]
        public double PointX { get; set; }
        [JsonIgnore]
        public double PointY { get; set; }
        [JsonIgnore]
        public virtual ICollection<Family> Families { get; set; }
        [JsonIgnore]
        public virtual ICollection<StationOfRoute> StationOfRoutes { get; set; }
    }
}
