using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class StationOfRoute
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int StationId { get; set; }
        public TimeSpan? AssumArrivalTime { get; set; }
        [JsonIgnore]
        public virtual Route Route { get; set; }
        [JsonIgnore]
        public virtual Station Station { get; set; }
    }
}
