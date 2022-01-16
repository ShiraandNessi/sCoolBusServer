using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Route
    {
        public Route()
        {
            StationOfRoutes = new HashSet<StationOfRoute>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public TimeSpan StartTime { get; set; }
        [JsonIgnore]
        public TimeSpan AssumEndTime { get; set; }
        [JsonIgnore]
        public bool Direction { get; set; }
        public int? DriverId { get; set; }
       
        public virtual Driver Driver { get; set; }
        
        public virtual ICollection<StationOfRoute> StationOfRoutes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
