using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class StationOfRoute
    {
        public int StationOfRouteId { get; set; }//
        public int RouteId { get; set; }
        public int StationId { get; set; }
        public TimeSpan? AssumArrivalTime { get; set; }

        public virtual Route Route { get; set; }
        public virtual Station Station { get; set; }
    }
}
