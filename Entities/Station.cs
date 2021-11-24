using System;
using System.Collections.Generic;

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
        public double PointX { get; set; }
        public double PointY { get; set; }

        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<StationOfRoute> StationOfRoutes { get; set; }
    }
}
