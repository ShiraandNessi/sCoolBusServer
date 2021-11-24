using System;
using System.Collections.Generic;
using static Entities.StationOfRoute;
#nullable disable

namespace Entities
{//test//////
    public partial class Route
    {
        public Route()
        {
            StationOfRoutes = new HashSet<StationOfRoute>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan AssumEndTime { get; set; }
        public bool Direction { get; set; }
        public int? DriverId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual ICollection<StationOfRoute> StationOfRoutes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
